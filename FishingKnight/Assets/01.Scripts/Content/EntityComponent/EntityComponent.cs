using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityComponent : MonoBehaviour
{
    protected Entity entity;
    public Entity Entity => entity;

    public virtual void Initialize(Entity owner)
    {
        entity = owner;
    }

    public virtual void PostInitialize() { }

    public virtual void UpdateComponent() { }
}