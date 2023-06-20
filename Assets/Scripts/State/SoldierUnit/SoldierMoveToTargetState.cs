using System.Collections.Generic;
using _Scripts.Tiles;
using DG.Tweening;
using Tarodev_Pathfinding._Scripts;
using UnityEngine;

public class SoldierMoveToTargetState : SoldierStateBase
{
    public SoldierMoveToTargetState(SoldierUnit soldierUnit) : base(soldierUnit)
    {
    }

    private Sequence moveSequence;

    private List<NodeBase> GetPath()
    {
        List<NodeBase> path = Pathfinding.FindPath(soldierUnit.CurrentNode, soldierUnit.TargetNode);

        if (path == null || path.Count == 0)
            return null;
        
            
        path.Reverse();

        return path;
    }

    private void HandleOnReachedTarget()
    {
        soldierUnit.SoldierStateController.ChangeState(soldierUnit.SoldierAttackController.HasCurrentTarget
            ? SoldierState.Attack
            : SoldierState.Idle);
    }

    private void CheckIfCanMove(NodeBase nodeBase)
    {
        if (!nodeBase.IsAvailable || !nodeBase.Walkable)
            soldierUnit.SoldierStateController.ChangeState(SoldierState.Idle);
    }


    public override void EnterState()
    {
        List<NodeBase> path = GetPath();
        
        if (path == null)
        {
            soldierUnit.transform.DOMove(soldierUnit.TargetNode.transform.position, 0.25f)
                .OnComplete(HandleOnReachedTarget);
            return;
        }
        
        moveSequence = DOTween.Sequence();

        moveSequence.OnComplete(HandleOnReachedTarget);

        foreach (var nodeBase in path)
            moveSequence.Append(soldierUnit.transform.DOMove(nodeBase.transform.position, 1f)
                .OnStart(() => CheckIfCanMove(nodeBase)).OnComplete(() => soldierUnit.CurrentNode = nodeBase));
    }

    public override void UpdateState()
    {
    }

    public override void ExitState()
    {
        moveSequence.Kill();
        soldierUnit.transform.DOKill();
    }
}