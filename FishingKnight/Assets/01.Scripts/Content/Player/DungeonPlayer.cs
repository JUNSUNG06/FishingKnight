using DG.Tweening;
using OMG.Inputs;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DungeonPlayer : MonoBehaviour
{
    [SerializeField] private PlayInputSO inputSO;

    [Space]
    [SerializeField] private string gridTag;

    private bool isDrag;
    private IDrag dragObject;

    private HexGrid currentGrid;
    private HexGrid dragStartGrid;

    private void Start()
    {
        InputManager.ChangeInputMap(InputMapType.Play);

        inputSO.RegistAction(PlayInputActionType.LeftMouse, OnMouseLeft);

        isDrag = false;
    }

    private void OnDestroy()
    {
        inputSO.UnregistAction(PlayInputActionType.LeftMouse, OnMouseLeft);
    }

    private void OnMouseLeft(InputAction.CallbackContext context)
    {
        if(context.started && !isDrag)
        {
            StartDrag();
        }
        else if(context.canceled && isDrag)
        {
            EndDrag();
        }
    }

    private void Update()
    {
        Ray ray = Manager.Instance.Camera.MainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if(hitInfo.collider.CompareTag(gridTag))
            {
                if(hitInfo.collider.TryGetComponent<HexGrid>(out HexGrid grid))
                {
                    if (currentGrid == null)
                    {
                        currentGrid = grid;
                        currentGrid.StartFocus(null);
                    }
                    else if(currentGrid != grid)
                    {
                        currentGrid.EndFocus(null);
                        currentGrid = grid;
                        currentGrid.StartFocus(null);
                    }
                }
            }
            else
            {
                if (currentGrid != null)
                {
                    currentGrid.EndFocus(null);
                    currentGrid = null;
                }
            }
        }
        else
        {
            if(currentGrid != null)
            {
                currentGrid.EndFocus(null);
                currentGrid = null;
            }
        }

        if(isDrag)
        {
            Dragging();
        }
    }

    private void StartDrag()
    {
        if(currentGrid == null)
        {
            FailDrag();
            return;
        }

        if(currentGrid.ArrangementObject == null)
        {
            FailDrag();
            Debug.Log("not exist arrangement object");
            return;
        }

        IDrag dragObject = currentGrid.ArrangementObject.GetTransform().GetComponent<IDrag>();
        if(dragObject == null)
        {
            FailDrag();
            return;
        }

        dragStartGrid = currentGrid;
        this.dragObject = dragObject;

        isDrag = true;
    }

    private void Dragging()
    {
        Ray ray = Manager.Instance.Camera.MainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            dragObject.GetTransform().position = new Vector3(
                hitInfo.point.x, dragObject.GetTransform().position.y, hitInfo.point.z);
        }
    }

    private void EndDrag()
    {
        if (currentGrid == null)
        {
            FailDrag();
            return;
        }

        if(currentGrid.arrangeType != PawnType.Player)
        {
            FailDrag();
            return;
        }

        SuccessDrag();
    }

    private void SuccessDrag()
    {
        dragStartGrid.UnArrangement();
        if (currentGrid.ArrangementObject != null)
        {
            IArrangement currentGridArrangementObject = currentGrid.UnArrangement();
            dragStartGrid.Arrangement(currentGridArrangementObject);
        }
        currentGrid.Arrangement(dragObject.GetTransform().GetComponent<IArrangement>());

        dragStartGrid = null;
        dragObject = null;
        isDrag = false;
    }

    private void FailDrag()
    {
        if(dragObject != null)
        {
            dragObject.GetTransform().position = dragStartGrid.transform.position;
        }

        dragStartGrid = null;
        dragObject = null;
        isDrag = false;
    }
}
