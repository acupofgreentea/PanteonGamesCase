using UnityEngine;

public class SoldierHealth : HealthBase
{
    private SoldierUnit soldierUnit;
    
    public SoldierHealth Init(SoldierUnit soldierUnit)
    {
        this.soldierUnit = soldierUnit;
        return this;
    }

    [ContextMenu("kill")]
    public void Kill()
    {
        TakeDamage(100);
    }

    protected override void Die()
    {
        base.Die();
        SoldierPool.Instance.ReturnToPool(soldierUnit);
    }
}