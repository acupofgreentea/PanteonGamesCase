using System.Collections.Generic;
using UnityEngine;

public class ProductionMenuUI : MonoBehaviour
{
    [SerializeField] private List<PlaceableBuildingSo> buildings;

    [SerializeField] private List<ProductionItemUI> productionItems;

    private void Awake()
    {
        foreach (ProductionItemUI t in productionItems)
        {
            t.Init(buildings.GetRandomItem());
        }
    }
}