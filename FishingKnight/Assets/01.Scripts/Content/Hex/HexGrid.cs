using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
public class HexGrid : MonoBehaviour, IFocus
{
    private IArrangement arrangementObject;
    public IArrangement ArrangementObject => arrangementObject;

    public HexRenderer render;

    [Space]
    public DungeonPawnType arrangeType;

    [Space]
    public GridType gridType;

    public void StartFocus(Entity performer)
    {
        render.OnFocus();
    }

    public void EndFocus(Entity performer)
    {
        render.OnUnFocus();
    }

    public Entity GetEntity()
    {
        return null;
    }

    public void Arrangement(IArrangement arrangementObject)
    {
        this.arrangementObject = arrangementObject;
        arrangementObject.GetTransform().position = transform.position;
        arrangementObject.OnArrangement(this);
    }

    public IArrangement UnArrangement()
    {
        IArrangement arrangement = arrangementObject;
        arrangementObject = null;

        return arrangement;
    }
}
