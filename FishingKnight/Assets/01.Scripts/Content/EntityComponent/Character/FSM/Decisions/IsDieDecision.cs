using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsDieDecision : FSMDecision
{
    private CharacterHealth health;

    public override void Initialize(Character character)
    {
        base.Initialize(character);

        health = character.GetEntityComponent<CharacterHealth>();
    }

    public override void Satisfy()
    {
        result = health.IsDie;
    }
}
