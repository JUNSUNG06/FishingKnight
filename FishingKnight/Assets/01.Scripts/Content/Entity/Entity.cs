using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private List<EntityComponent> comps;
    private Dictionary<Type, EntityComponent> compDictionary;

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
        compDictionary = new Dictionary<Type, EntityComponent>();
        foreach (EntityComponent comp in comps)
        {
            Type type = comp.GetType();
            while (type.Name != $"{GetType()}Component")
            {
                compDictionary.Add(type, comp);
                type = comp.GetType().BaseType;
            }

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
        return compDictionary[typeof(T)] as T;
    }
}