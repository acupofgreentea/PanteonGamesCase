using UnityEngine;

[CreateAssetMenu(menuName = "PlaceableBuilding")]
public class PlaceableBuildingSo : PlaceableSo
{
    [field: SerializeField] public BuildingBase BuildingPrefab {get; private set; }
}