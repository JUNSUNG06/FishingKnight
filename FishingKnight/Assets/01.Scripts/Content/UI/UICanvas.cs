using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : UIObject
{
    private Dictionary<Type, UIPanel> panels;

    private void Awake()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();

        panels = new Dictionary<Type, UIPanel>();
        foreach(Transform child in transform)
        {
            if(child.TryGetComponent<UIPanel>(out UIPanel panel))
            {
                panels.Add(panel.GetType(), panel);
                panel.Initialize();
            }
        }
    }

    public T GetPanel<T>() where T : UIPanel
    {
        return panels[typeof(T)] as T;
    }
}
