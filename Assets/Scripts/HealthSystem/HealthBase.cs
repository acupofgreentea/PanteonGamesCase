using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthBase : MonoBehaviour
{
    [SerializeField] private HealthSO healthSo;

    protected float maxHealth;
    public float CurrentHealth { get; private set; }
    
    public UnityAction OnDie { get; set; }


    private void OnEnable()
    {
        InitializeHealth();
    }

    private void InitializeHealth()
    {
        maxHealth = healthSo.MaxHealth;
        CurrentHealth = maxHealth;
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
        OnDie?.Invoke();   
    }
}