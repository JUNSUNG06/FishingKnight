using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteract : CharacterComponent
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float distance;
    [SerializeField] private Vector3 halfExtents;
    [SerializeField] private LayerMask interactLayer;

    private IInteract interactableObject; 

    public void FindObject()
    {
        Collider[] hits = Physics.OverlapBox(character.transform.position +
            character.transform.rotation * direction * distance,
            halfExtents,
            Quaternion.identity,
            interactLayer);

        if(hits.Length > 0)
        {
            if(interactableObject == null)
            {
                Debug.Log(hits[0].name);       
                hits[0].TryGetComponent<IInteract>(out interactableObject);
            }
        }
        else
        {
            interactableObject = null;
        }
    }

    public void Interact()
    {
        if (interactableObject != null)
            interactableObject.Interact(entity);
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = interactableObject == null ? Color.red : Color.green;
        Gizmos.DrawWireCube(transform.position + 
            transform.rotation * direction * distance, halfExtents * 2);
    }
#endif
}
