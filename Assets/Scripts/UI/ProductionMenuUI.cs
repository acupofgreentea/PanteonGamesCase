using System;
using System.Collections;
using UnityEngine;

public class ProductionMenuUI : MonoBehaviour
{
    [SerializeField] private Transform contentParent;

    [SerializeField] private int initialCount = 20;

    private ProductionMenuPool productionMenuPool;
    
    private readonly Queue productionItemUIQueue = new Queue();
    private void Awake()
    {
        productionMenuPool = GetComponent<ProductionMenuPool>();

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
        ProductionItemUI item = productionMenuPool.Get();

        item.transform.SetParent(contentParent);
        productionItemUIQueue.Enqueue(item);
    }
    
    [ContextMenu("Hide")]
    private void Hide()
    {
        ProductionItemUI item = (ProductionItemUI) productionItemUIQueue.Dequeue();
        productionMenuPool.ReturnToPool(item);

        if (productionItemUIQueue.Count < initialCount)
            Show();
    }

    private void OnDestroy()
    {
        BuildManager.Instance.OnBuilt -= Hide;
    }
}