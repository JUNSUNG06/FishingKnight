using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public CameraManager()
    {

    }
}
