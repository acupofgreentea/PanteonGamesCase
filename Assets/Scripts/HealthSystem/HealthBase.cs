using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [SerializeField] private HealthSO healthSo;

    protected float maxHealth;
    public float CurrentHealth { get; private set; }
    
    public HealthBase Init()
    {
        maxHealth = healthSo.MaxHealth;
        CurrentHealth = maxHealth;
        
        return this;
    }

    public virtual void TakeDamage(float damage)
    {
        if (CurrentHealth <= 0)
            return;

        CurrentHealth -= damage;
        
        if(CurrentHealth <= 0)
            Die();
    }

    protected virtual void Die()
    {
        
    }
}