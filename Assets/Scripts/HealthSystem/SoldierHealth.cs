public class SoldierHealth : HealthBase
{
    private SoldierUnit soldierUnit;
    
    public SoldierHealth Init(SoldierUnit soldierUnit)
    {
        this.soldierUnit = soldierUnit;
        return this;
    }
}