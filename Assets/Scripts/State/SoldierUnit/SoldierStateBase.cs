public abstract class SoldierStateBase
{
    protected SoldierUnit soldierUnit;
    public SoldierStateBase(SoldierUnit soldierUnit)
    {
        this.soldierUnit = soldierUnit;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
}