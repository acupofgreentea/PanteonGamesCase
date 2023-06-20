using UnityEngine;

public class BarrackBuilding : BuildingBase, IHaveProduct
{
    private new PlaceableBuildingSo PlaceableSo => (PlaceableBuildingSo)base.PlaceableSo;
    
    public BuildingSoldierSpawner BuildingSoldierSpawner { get; private set; }
    
    [field: SerializeField] public BuildingProductionUISO BuildingProductionUISO { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        
        BuildingSoldierSpawner = GetComponent<BuildingSoldierSpawner>().Init(this);
    }

}