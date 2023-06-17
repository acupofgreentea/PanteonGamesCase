using UnityEngine;

public abstract class BuildingBase : MonoBehaviour
{
    [field: SerializeField] public PlaceableSo PlaceableSo { get; private set; }

    [SerializeField] private SpriteRenderer buildingVisual;

    public PlaceableDimension Dimension => PlaceableSo.PlaceableDimension;

    protected virtual void Start()
    {
        buildingVisual.sprite = PlaceableSo.PlaceableSprite;
    }
}