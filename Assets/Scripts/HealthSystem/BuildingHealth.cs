public class BuildingHealth : HealthBase
{
    private BuildingBase buildingBase;
    
    public BuildingHealth Init(BuildingBase buildingBase)
    {
        this.buildingBase = buildingBase;
        return this;
    }
}