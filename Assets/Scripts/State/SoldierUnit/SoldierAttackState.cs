public class SoldierAttackState : SoldierStateBase
{
    public SoldierAttackState(SoldierUnit soldierUnit) : base(soldierUnit)
    {
    }


    public override void EnterState()
    {
    }

    public override void UpdateState()
    {
        soldierUnit.SoldierAttackController.Attack();
    }

    public override void ExitState()
    {
    }
}