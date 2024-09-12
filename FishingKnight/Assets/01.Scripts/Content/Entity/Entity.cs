using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private List<EntityComponent> comps;

    protected virtual void Awake()
    {
        
    }

    protected virtual void Start()
    {
        Init();
    }

    private void Update()
    {
        for(int i = 0; i < comps.Count; i++)
        {
            comps[i].UpdateComponent();
        }
    }

    public void Init()
    {
        comps = new List<EntityComponent>();
        GetComponents<EntityComponent>(comps);
        foreach (EntityComponent comp in comps)
        {
            comp.Initialize(this);
        }

        foreach (EntityComponent comp in comps)
        {
            comp.PostInitialize();
        }
    }
    
    public T GetEntityComponent<T>() where T : EntityComponent
    {
        //T result = null;

        //for (int i = 0; i < comps.Count; i++)
        //{
        //    if (comps[i] is T)
        //    {
        //        result = comps[i] as T;

        //        break;
        //    }
        //}

        return GetComponent<T>();
    }
}