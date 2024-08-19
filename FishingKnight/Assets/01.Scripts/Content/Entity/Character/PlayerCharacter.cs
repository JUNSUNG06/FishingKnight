using OMG.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    protected override void Awake()
    {
        base.Awake();

        InputManager.ChangeInputMap(InputMapType.Play);
    }

    public override void OnDamaged(Entity attacker, float power, Vector3 point, Vector3 direction = default, Vector3 normal = default)
    {
        base.OnDamaged(attacker, power, point, direction, normal);

        GetEntityComponent<CharacterHealth>().RemoveHealth(power);
    }
}