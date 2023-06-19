using System.Collections.Generic;
using _Scripts.Tiles;
using DG.Tweening;
using Tarodev_Pathfinding._Scripts;

public class SoldierMoveToTargetState : SoldierStateBase
{
    public SoldierMoveToTargetState(SoldierUnit soldierUnit) : base(soldierUnit)
    {
    }

    private List<NodeBase> GetPath()
    {
        List<NodeBase> path = Pathfinding.FindPath(soldierUnit.CurrentNode, soldierUnit.TargetNode);

        path.Reverse();

        return path;
    }

    public override void EnterState()
    {
        List<NodeBase> path = GetPath();
        
        Sequence sequence = DOTween.Sequence();

        foreach (var nodeBase in path)
            sequence.Append(soldierUnit.transform.DOMove(nodeBase.transform.position, 3f));
    }

    public override void ExitState()
    {
    }
}