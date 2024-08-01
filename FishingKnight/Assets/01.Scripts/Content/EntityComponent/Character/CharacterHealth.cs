using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterHealth : EntityComponent
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
    #endregion
    #region Events
    public UnityEvent<float, float/*prev, new*/> OnHealthChanged;
    #endregion

    public override void Initialize(Entity owner)
    {
        base.Initialize(owner);

        health = maxHealth;
    }

    public void ChangeHealth(float value)
    {
        Health = value;
    }

    public void AddHealth(float amount)
    {
        health += amount;
    }

    public void RemoveHealth(float amount)
    {
        health -= amount;
    }
}
