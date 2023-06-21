public class BuildingHealth : HealthBase
{
    private BuildingBase buildingBase;
    
    public BuildingHealth Init(BuildingBase buildingBase)
    {
        this.buildingBase = buildingBase;
        return this;
    }

    protected override void Die()
    {
        base.Die();
        this.DelayMethod(()=>BuildingPool.Instance.ReturnToPool(buildingBase));
    }
}