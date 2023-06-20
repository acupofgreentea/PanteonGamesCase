using UnityEngine;

public class SoldierAttackController : AttackControllerBase
{
    private SoldierUnit soldierUnit;

    public SoldierAttackController Init(SoldierUnit soldierUnit)
    {
        this.soldierUnit = soldierUnit;
        
        return this;
    }

    private bool CanAttack => Time.time > lastAttackTime + AttackStatsSo.AttackRate;
    public bool HasCurrentTarget => CurrentTarget != null;

    protected override void HandleOnTargetDie()
    {
        base.HandleOnTargetDie();
        soldierUnit.SoldierStateController.ChangeState(SoldierState.Idle);
    }

    public override void Attack()
    {
        if (CurrentTarget == null)
            return;
        
        if (!CanAttack)
            return;
        
        CurrentTarget.TakeDamage(AttackStatsSo.AttackDamage);
        lastAttackTime = Time.time;
    }
}