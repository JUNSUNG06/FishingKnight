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
}