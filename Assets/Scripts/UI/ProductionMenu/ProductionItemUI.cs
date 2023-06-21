using UnityEngine;
using UnityEngine.UI;

public class ProductionItemUI : MonoBehaviour
{
    private Image image;
    private PlaceableBuildingSo placeableSo;

    public void Init(PlaceableBuildingSo placeableSo)
    {
        this.placeableSo = placeableSo;
        image = GetComponent<Image>();
        image.sprite = placeableSo.PlaceableSpriteUI;
    }

    public void SetCurrentBuilding()
    {
        BuildManager.Instance.CurrentBuilding = placeableSo.BuildingPrefab;
    }
}