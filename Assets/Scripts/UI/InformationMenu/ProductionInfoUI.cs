using System;
using TMPro;
using UnityEngine;

public class ProductionInfoUI : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private TextMeshProUGUI productionsText;

    private BuildingProductionItemSinglePool pool;

    private void Awake()
    {
        pool = GetComponent<BuildingProductionItemSinglePool>();
    }

    private void Start()
    {
        SetActivePanel(false);
    }

    public void Setup()
    {
        Transform selectable = SelectionManager.Instance.LastSelected;
        SetActivePanel(false);

        if (content.transform.childCount > 0)
        {
            foreach (Transform item in content.transform)
            {
                if(content.transform.childCount == 0)
                    break;
            
                pool.ReturnToPool(item.GetComponent<BuildingProductionItemUI>());
            }
        }

        if (!selectable.TryGetComponent(out IHaveProduct haveProduct))
            return;
        
        SetActivePanel(true);
        SetContent(haveProduct.BuildingProductionUISO);
    }

    private void SetContent(BuildingProductionUISO buildingProduction)
    {
        foreach (var itemProduction in buildingProduction.Productions)
        {
            BuildingProductionItemUI item = pool.Get();
            item.transform.SetParent(content.transform);
            item.Init(itemProduction.ProductionSprite);
        }
    }
    
    private void SetActivePanel(bool enable)
    {
        productionsText.gameObject.SetActive(enable);
        content.gameObject.SetActive(enable);
    }
}