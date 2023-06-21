
public class BuildingPool : MultiplePoolBase<BuildingBase>
{
    public static BuildingPool Instance { get; private set; }

    protected override void Awake()
    {
        if(Instance)
        {
            Destroy(this);
            return;
        }
        
        Instance = this;
        
        base.Awake();
    }
}