
public class SoldierSinglePool : SinglePoolBase<SoldierUnit>
{
    public static SoldierSinglePool Instance { get; private set; }

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