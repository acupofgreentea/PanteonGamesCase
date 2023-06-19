using System;
using System.Collections.Generic;
using _Scripts.Tiles;
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

    private void Start()
    {
        SelectionManager.Instance.OnTargetNodeSelected += TargetNodeSelected;
    }

    private void TargetNodeSelected(NodeBase target)
    {
        soldierUnit.TargetNode = target;
        ChangeState(SoldierState.MoveToTarget);
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