using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : CharacterComponent, IDamage
{
    [SerializeField][Min(0f)] private float maxHealth;
    private float health;

    #region Properties
    public float MaxHealth => maxHealth;
    public float Health
    {
        get 
        { 
            return health;
        }
        set
        {
            float prev = health;
            health = value;
            health = Mathf.Clamp(health, 0f, maxHealth);

            OnHealthChanged?.Invoke(prev, health);
        }
    }

    public bool IsDie { get; private set; }
    #endregion
    #region Events
    public UnityEvent<float, float/*prev, new*/> OnHealthChanged;

    public UnityEvent OnDie;
    #endregion

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        health = maxHealth;
    }

    public void ChangeHealth(float value)
    {
        Health = Mathf.Clamp(value, 0f, MaxHealth);
    }

    public void AddHealth(float amount)
    {
        Health = Mathf.Min(health + amount, MaxHealth);
    }

    public void RemoveHealth(float amount)
    {
        Health = Mathf.Max(health - amount, 0f);
    }

    public virtual void OnDamaged(Entity attacker, float power, Vector3 point,
        Vector3 direction = default, Vector3 normal = default)
    {
        RemoveHealth(power);

        if(Health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        IsDie = true;
        OnDie?.Invoke();
    }
}
