using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusCamera : MonoBehaviour
{
    [SerializeField] private float focusTime;
    public float FocusTime => focusTime;

    private CinemachineVirtualCamera cam;
    public CinemachineVirtualCamera Cam => cam;

    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    public void StartFocus()
    {
        Manager.Instance.Camera.ChangeCamera(cam, focusTime);
    }

    public void EndFocus()
    {
        Debug.Log("end focus");
        Manager.Instance.Camera.ChangePrevCamera(focusTime);
    }
}