using System.Collections;
using UnityEngine;

public class SoldierHealth : HealthBase
{
    private SoldierUnit soldierUnit;
    
    public SoldierHealth Init(SoldierUnit soldierUnit)
    {
        this.soldierUnit = soldierUnit;
        return this;
    }

    [ContextMenu("Kill")]
    public void Kill()
    {
        TakeDamage(100);
    }

    protected override void Die()
    {
        base.Die();

        this.DelayMethod(()=> SoldierPool.Instance.ReturnToPool(soldierUnit));
    }
}