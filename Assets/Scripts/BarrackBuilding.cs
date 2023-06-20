
public class BarrackBuilding : BuildingBase
{
    private new PlaceableBuildingSo PlaceableSo => (PlaceableBuildingSo)base.PlaceableSo;
    
    public BuildingSoldierSpawner BuildingSoldierSpawner { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        
        BuildingSoldierSpawner = GetComponent<BuildingSoldierSpawner>().Init(this);
    }
}