using UnityEngine;

public class BuildingPool : MultiplePoolBase<BuildingBase>
{
    [ContextMenu("Get")]
    public void Get()
    {
        Get(BuildManager.Instance.CurrentBuilding);
    }
    
}