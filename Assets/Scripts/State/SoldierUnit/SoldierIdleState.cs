using _Scripts.Tiles;
using DG.Tweening;
using UnityEngine;

public class SoldierIdleState : SoldierStateBase
{
    public SoldierIdleState(SoldierUnit soldierUnit) : base(soldierUnit)
    {
        
    }

    private readonly float maxStateDuration = 3f;

    private float enterStateTime;
    public override void EnterState()
    { 
        ChangeNode();
        
        soldierUnit.transform.DOMove(soldierUnit.CurrentNode.transform.position, 0.25f);
        enterStateTime = Time.time;
        
        //play idle animation etc.
    }

    private void ChangeNode()
    {
        if (soldierUnit.CurrentNode.IsAvailable && soldierUnit.CurrentNode.Walkable)
            return;

        NodeBase currentNode = soldierUnit.CurrentNode;
        soldierUnit.CurrentNode = currentNode.GetAvailableClosestToTargetNeighbor(soldierUnit.transform);
    }

    public override void UpdateState()
    {
        if (Time.time < enterStateTime + maxStateDuration)
            return;
        
        soldierUnit.SoldierStateController.ChangeState(SoldierState.Patrol);
    }

    public override void ExitState()
    {
        
    }
}