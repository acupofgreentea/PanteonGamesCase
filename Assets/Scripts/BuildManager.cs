using System.Collections;
using System.Collections.Generic;
using _Scripts.Tiles;
using Tarodev_Pathfinding._Scripts.Grid;
using UnityEngine;
using UnityEngine.Events;

public class BuildManager : MonoBehaviour
{
    [field: SerializeField] public BuildingBase CurrentBuilding { get; private set; }
    
    public static BuildManager Instance { get; private set; }
    
    public UnityAction OnBuilt { get; set; }
    
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
            StartCoroutine(BuildFailSequence(nodeBase));
            return;
        }

        OnBuilt?.Invoke();
        
        var build = Instantiate(CurrentBuilding);
        
        List<NodeBase> otherNodes = GridManager.Instance.GetNodesAtDirections(nodeBase, nodeBase.GetDirectionByDimension(CurrentBuilding.Dimension));
        build.OccupiedNodes = otherNodes;

        foreach (NodeBase otherNode in otherNodes)
        {
            otherNode.IsAvailable = false;
            otherNode.Walkable = false;
        }
        
        build.transform.position = nodeBase.GetPositionByDimension(build.Dimension);
    }

    private IEnumerator BuildFailSequence(NodeBase nodeBase)
    {
        List<NodeBase> otherNodes = GridManager.Instance.GetNodesAtDirections(nodeBase, nodeBase.GetDirectionByDimension(CurrentBuilding.Dimension));

        foreach (NodeBase otherNode in otherNodes)
            otherNode.NodeSpriteController.ChangeNodeColor(Color.red, 0.5f);

        yield return new WaitForSeconds(0.6f);
        
        foreach (NodeBase otherNode in otherNodes)
            otherNode.NodeSpriteController.ChangeNodeColor(otherNode.NodeSpriteController.GetDefaultColor, 0.5f);
        
    }
}