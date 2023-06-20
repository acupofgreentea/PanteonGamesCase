using System;
using System.Collections;
using UnityEngine;

public class ProductionMenuUI : MonoBehaviour
{
    [SerializeField] private Transform contentParent;

    [SerializeField] private int initialCount = 20;

    private ProductionMenuSinglePool productionMenuSinglePool;
    
    private readonly Queue productionItemUIQueue = new Queue();
    private void Awake()
    {
        productionMenuSinglePool = GetComponent<ProductionMenuSinglePool>();

        for (int i = 0; i < initialCount; i++)
        {
            Show();
        }
    }

    private void Start()
    {
        BuildManager.Instance.OnBuilt += Hide;
    }

    [ContextMenu("Show")]
    private void Show()
    {
        ProductionItemUI item = productionMenuSinglePool.Get();

        item.transform.SetParent(contentParent);
        productionItemUIQueue.Enqueue(item);
    }
    
    [ContextMenu("Hide")]
    private void Hide()
    {
        ProductionItemUI item = (ProductionItemUI) productionItemUIQueue.Dequeue();
        productionMenuSinglePool.ReturnToPool(item);

        if (productionItemUIQueue.Count < initialCount)
            Show();
    }

    private void OnDestroy()
    {
        BuildManager.Instance.OnBuilt -= Hide;
    }
}