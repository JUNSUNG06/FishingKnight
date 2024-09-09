using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
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
    private CinemachineBrain brain;

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
    private CinemachineVirtualCamera prevCamera;

    private readonly int DefaultPriority = 0;
    private readonly int FocusPriority = 10;

    public CameraManager()
    {

    }

    public void ChangeCamera(CinemachineVirtualCamera cam, float time)
    {
        if (cam == null)
            return;

        if(brain == null)
            brain = MainCamera.GetComponent<CinemachineBrain>();
        brain.m_DefaultBlend.m_Time = time;

        if(currentCamera != null)
        {
            currentCamera.Priority = DefaultPriority;
            prevCamera = currentCamera;
        }
        currentCamera = cam;
        currentCamera.Priority = FocusPriority;
    }

    public void ChangePrevCamera(float time)
    {
        ChangeCamera(prevCamera, time);
    }
}
