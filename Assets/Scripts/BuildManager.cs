using _Scripts.Tiles;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [field: SerializeField] public BuildingBase CurrentBuilding { get; private set; }
    
    public static BuildManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void Build(bool isAbleToBuild, NodeBase nodeBase)
    {
        if (!isAbleToBuild)
        {
            Debug.LogError("You cannot build here!");
            return;
        }

        var build = Instantiate(CurrentBuilding);
        build.transform.position = nodeBase.GetPositionByDimension(build.Dimension);
    }
}