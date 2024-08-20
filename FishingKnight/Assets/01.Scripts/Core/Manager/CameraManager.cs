using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager
{
    private Camera mainCamera;
    public Camera MainCamera
    {
        get
        {
            if(mainCamera == null)
            {
                mainCamera = Camera.main;
            }

            return mainCamera;
        }
    }

    public Quaternion CameraForward
    {
        get
        {
            if (MainCamera == null)
                return Quaternion.identity;

            return Quaternion.Euler(MainCamera.transform.eulerAngles.y * Vector3.up);
        }
    }

    private CinemachineVirtualCamera currentCamera;

    private readonly int DefaultPriority = 0;
    private readonly int FocusPriority = 10;

    public CameraManager()
    {

    }

    public void ChangeCamera(CinemachineVirtualCamera cam)
    {
        if(currentCamera != null)
            currentCamera.Priority = DefaultPriority;
        currentCamera = cam;
        currentCamera.Priority = FocusPriority;
    }
}
