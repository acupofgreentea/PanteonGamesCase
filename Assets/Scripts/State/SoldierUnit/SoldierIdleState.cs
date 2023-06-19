using UnityEngine;

public class SoldierIdleState : SoldierStateBase
{
    public SoldierIdleState(SoldierUnit soldierUnit) : base(soldierUnit)
    {
        
    }

    private float maxStateDuration = 3f;

    private float enterStateTime;
    public override void EnterState()
    {
        enterStateTime = Time.time;
        //play idle animation etc.
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