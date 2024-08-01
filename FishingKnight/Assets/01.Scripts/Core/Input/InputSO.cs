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
        inputActions = new Dictionary<T, Action<CallbackContext>>();
        foreach (T type in Enum.GetValues(typeof(T)))
        {
            inputActions.Add(type, null);
        }
    }

    public void RegistAction(T type, Action<CallbackContext> action)
    {
        inputActions[type] += action;
    }

    public void UnregistAction(T type, Action<CallbackContext> action)
    {
        inputActions[type] -= action;
    }
}