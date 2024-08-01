using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityComponent : MonoBehaviour
{
    protected Entity owner;
    public Entity Owner => owner;

    public virtual void Initialize(Entity owner)
    {
        this.owner = owner;
    }

    public virtual void PostInitializeComponent() { }
}