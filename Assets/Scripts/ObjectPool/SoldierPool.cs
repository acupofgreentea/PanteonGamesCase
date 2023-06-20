
public class SoldierPool : PoolBase<SoldierUnit>
{
    public static SoldierPool Instance { get; private set; }

    protected override void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        base.Awake();
    }
}