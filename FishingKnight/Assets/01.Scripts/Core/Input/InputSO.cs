using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class InputSO<T> : ScriptableObject
{
    public InputMapType inputMapType;
    protected Dictionary<T, Action<CallbackContext>> inputActions;

    protected virtual void OnEnable()
    {
        Debug.Log($"Set InputSO : {inputMapType}");
        foreach (T type in Enum.GetValues(typeof(T)))
        {
            inputActions.Add(type, null);
        }
    }
}