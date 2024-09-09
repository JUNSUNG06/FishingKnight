using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : CharacterComponent
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float distance;
    [SerializeField] private Vector3 halfExtents;
    [SerializeField] private LayerMask interactLayer;

    private IFocus focusingObject;
    private IInteract interactingObject; 

    public void Focusing()
    {
        Collider[] hits = Physics.OverlapBox(character.transform.position +
            character.transform.rotation * direction * distance,
            halfExtents,
            Quaternion.identity,
            interactLayer);

        if(hits.Length > 0)
        {
            if(focusingObject == null)
            {    
                hits[0].TryGetComponent<IFocus>(out focusingObject);
            }
        }
        else
        {
            focusingObject = null;
        }
    }

    public void Interact()
    {
        if (focusingObject != null)
        {
            if(focusingObject.GetEntity().TryGetComponent<IInteract>(out interactingObject))
            {
                interactingObject.Interact(entity);
            }
        }
        else
        {
            Collider[] hits = Physics.OverlapBox(character.transform.position +
            character.transform.rotation * direction * distance,
            halfExtents,
            Quaternion.identity,
            interactLayer);

            if (hits.Length > 0)
            {
                if (hits[0].TryGetComponent<IInteract>(out interactingObject))
                {
                    interactingObject.Interact(entity);
                }
            }
        }
    }

    public void UnInteract()
    {
        if(interactingObject != null)
        {
            interactingObject.UnInteract(entity);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = focusingObject == null ? Color.red : Color.green;
        Gizmos.DrawWireCube(transform.position + 
            transform.rotation * direction * distance, halfExtents * 2);
    }
#endif
}
