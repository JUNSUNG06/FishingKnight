using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageArea : Area
{
    [Space]
    [SerializeField] private FocusCamera focusCam;

    public override void EnterArea()
    {
        base.EnterArea();

        focusCam.StartFocus();
    }
}