using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChangeTrigger : Trigger
{
    [SerializeField] private Area area;

    public override void OnTrigger(Collider other)
    {
        if(other.CompareTag("Player"))
            Manager.Instance.Area.ChangeArea(area);
    }
}
