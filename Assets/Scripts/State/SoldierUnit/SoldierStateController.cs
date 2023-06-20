using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierStateController : StateControllerBase<SoldierState, SoldierStateBase>
{
    private SoldierUnit soldierUnit;
    
    public SoldierStateController Init(SoldierUnit soldierUnit)
    {
        this.soldierUnit = soldierUnit;
        CreateDictionary();
        ChangeState(SoldierState.Empty);
        return this;
    }

    protected override void CreateDictionary()
    {
        stateDictionary = new Dictionary<SoldierState, SoldierStateBase>
        {
            { SoldierState.MoveToTarget, new SoldierMoveToTargetState(soldierUnit)},
            { SoldierState.Patrol, new SoldierPatrolState(soldierUnit)},
            { SoldierState.Idle, new SoldierIdleState(soldierUnit)},
            { SoldierState.Attack, new SoldierAttackState(soldierUnit)},
            { SoldierState.Empty, new SoldierEmptyState(soldierUnit)},
        };
    }

    private void Start()
    {
        soldierUnit.SoldierHealth.OnDie += HandleOnDie;
    }

    private void HandleOnDie()
    {
        ChangeState(SoldierState.Empty);
    }

    private void Update()
    {
        CurrentState?.UpdateState();
    }
    
    public override void ChangeState(SoldierState type)
    {
        CurrentState?.ExitState();
        base.ChangeState(type);
        CurrentState?.EnterState();
    }
    private void OnDestroy()
    {
        soldierUnit.SoldierHealth.OnDie -= HandleOnDie;
    }
}