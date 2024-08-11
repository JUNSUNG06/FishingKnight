using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private List<EntityComponent> comps;

    private void Start()
    {
        Initialize();
        PostInitializeComponent();
    }

    private void Update()
    {
        for(int i = 0; i < comps.Count; i++)
        {
            comps[i].UpdateComponent();
        }
    }

    protected virtual void Initialize()
    {
        foreach (EntityComponent comp in comps)
        {
            comp.Initialize(this);
        }
    }

    protected virtual void PostInitializeComponent()
    {
        foreach (EntityComponent comp in comps)
        {
            comp.PostInitializeComponent();
        }
    }

    public T GetEntityComponent<T>() where T : EntityComponent
    {
        T result = null;

        for (int i = 0; i < comps.Count; i++)
        {
            if (comps[i] is T)
            {
                result = comps[i] as T;

                break;
            }
        }

        return result;
    }
}