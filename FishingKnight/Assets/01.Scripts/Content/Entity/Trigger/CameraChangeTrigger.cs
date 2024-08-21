using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChangeTrigger : Trigger
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private float changeTime;

    public override void OnTrigger(Collider other)
    {
        if(other.CompareTag("Player"))
            Manager.Camera.ChangeCamera(cam, changeTime);
    }
}
