using UnityEngine;

public abstract class BuildingBase : MonoBehaviour
{
    [field: SerializeField] public PlaceableSo PlaceableSo { get; private set; }

    [SerializeField] private SpriteRenderer buildingVisual;

    private void Start()
    {
        buildingVisual.sprite = PlaceableSo.PlaceableSprite; 
    }
}