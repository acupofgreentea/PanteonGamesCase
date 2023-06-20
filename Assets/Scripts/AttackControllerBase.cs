using UnityEngine;

public abstract class AttackControllerBase : MonoBehaviour
{
    [SerializeField] protected AttackStatsSO attackStatsSo;
    
    protected float lastAttackTime;
    
    public HealthBase CurrentTarget { get; private set; }

    public void SetCurrentTarget(HealthBase healthBase)
    {
        if (CurrentTarget)
            CurrentTarget.OnDie -= HandleOnTargetDie;

        CurrentTarget = healthBase;
        
        if(CurrentTarget != null)
            CurrentTarget.OnDie += HandleOnTargetDie;
    }

    protected virtual void HandleOnTargetDie()
    {
        CurrentTarget.OnDie -= HandleOnTargetDie;

        CurrentTarget = null;
    }
    public abstract void Attack();
}