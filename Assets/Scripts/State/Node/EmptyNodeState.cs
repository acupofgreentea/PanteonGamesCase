using System.Collections.Generic;
using System.Linq;
using _Scripts.Tiles;
using Tarodev_Pathfinding._Scripts.Grid;
using UnityEngine;

public class EmptyNodeState : NodeStateBase
{
    public EmptyNodeState(NodeBase nodeBase) : base(nodeBase)
    {
        
    }

    private bool IsAbleToBuild()
    {
        var currentBuilding = BuildManager.Instance.CurrentBuilding;
        
        if(currentBuilding == null)
            return false;

        Vector2[] directions = nodeBase.GetDirectionByDimension(currentBuilding.Dimension);

        List<NodeBase> list = GridManager.Instance.GetNodesAtDirections(nodeBase, directions);

        if (!list.Contains(nodeBase))
            list.Add(nodeBase);

        if (list.Count != directions.Length)
            return false;

        if (list.Any(x => x.IsAvailable == false))
            return false;

        foreach (NodeBase node in list)
            node.IsAvailable = false;

        return true;
    }

    public override void HandleNodeSelected()
    {
        bool isAbleToBuild = IsAbleToBuild();

        BuildManager.Instance.Build(isAbleToBuild, nodeBase);

        if (!isAbleToBuild)
            return;

        nodeBase.NodeStateController.ChangeState(NodeState.Building);
    }
}