using System.Collections.Generic;
using UnityEngine;

public class SoldierStateController : StateControllerBase<SoldierState, SoldierStateBase>
{
    private SoldierUnit soldierUnit;
    
    public SoldierStateController Init(SoldierUnit soldierUnit)
    {
        this.soldierUnit = soldierUnit;
        CreateDictionary();
        return this;
    }

    protected override void CreateDictionary()
    {
        stateDictionary = new Dictionary<SoldierState, SoldierStateBase>()
        {
            { SoldierState.MoveToTarget, new SoldierMoveToTargetState(soldierUnit)},
            { SoldierState.Patrol, new SoldierPatrolState(soldierUnit)},
            { SoldierState.Idle, new SoldierIdleState(soldierUnit)},
            { SoldierState.Attack, new SoldierAttackState(soldierUnit)},
        };
    }

    private void Update()
    {
        CurrentState?.UpdateState();
    }

    //test
    [ContextMenu("Change")]
    public void Change()
    {
        ChangeState(SoldierState.Patrol);
    }
    public override void ChangeState(SoldierState type)
    {
        CurrentState?.ExitState();
        base.ChangeState(type);
        CurrentState?.EnterState();
    }
}