using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    private Dictionary<AnimationEventType, Action> events;

    private void Awake()
    {
        events = new Dictionary<AnimationEventType, Action>();
        foreach(AnimationEventType type in Enum.GetValues(typeof(AnimationEventType)))
        {
            events.Add(type, null);
        }
    }

    public void RegistEvent(AnimationEventType type, Action action)
    {
        events[type] += action;
    }

    public void UnregistEvent(AnimationEventType type, Action action)
    {
        events[type] -= action;
    }

    public void InvokeEvent(string eventName)
    {
        AnimationEventType type = (AnimationEventType)Enum.Parse(typeof(AnimationEventType), eventName);

        events[type]?.Invoke();
    }
}
