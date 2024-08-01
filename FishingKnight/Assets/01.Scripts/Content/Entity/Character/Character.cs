using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Entity, IDamage
{
    private CharacterHealth healthComp;

    protected override void PostInitializeComponent()
    {
        base.PostInitializeComponent();

        healthComp = GetEntityComponent<CharacterHealth>();
    }

    public void OnDamaged(Entity attacker, float power, Vector3 point,
        Vector3 direction = default, Vector3 normal = default)
    {
        healthComp.RemoveHealth(power);
    }
}