using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexGridLayout : MonoBehaviour
{
    public Vector2Int gridSize;

    public float innerSize = 0f;
    public float outerSize = 1f;
    public float height = 1f;
    public bool isFlatTopped;
    public Vector2 padding;
    public Material material;

    [Space]
    [SerializeField] private float focusedPower;
    [ColorUsage(true, true)][SerializeField] private Color focusedColor;
    [SerializeField] private float unFocusedPower;
    [ColorUsage(true, true)][SerializeField] private Color unFocusedColor;
    [SerializeField] private float transTime;

    private HexGrid[,] grids;

    private void OnEnable()
    {
        LayoutGrid();
    }

    private void OnValidate()
    {
        if(Application.isPlaying)
        {
            LayoutGrid();
        }
    }

    private void LayoutGrid()
    {
        transform.ClearChild();

        grids = new HexGrid[gridSize.y, gridSize.x];

        for (int y = 0; y < gridSize.y; y++)
        {
            for(int x = 0; x < gridSize.x; x++)
            {
                GameObject tile = new GameObject($"Hex({x}, {y})", typeof(HexRenderer));
                tile.tag = "HexGrid";

                HexRenderer hexRenderer = tile.GetComponent<HexRenderer>();
                hexRenderer.innerSize = innerSize;
                hexRenderer.outerSize = outerSize;
                hexRenderer.height = height;
                hexRenderer.isFlatTopped = isFlatTopped;
                hexRenderer.focusedColor = focusedColor;
                hexRenderer.focusedPower = focusedPower;
                hexRenderer.unFocusedColor = unFocusedColor;
                hexRenderer.unFocusedPower = unFocusedPower;
                hexRenderer.transTime = transTime;
                hexRenderer.SetMaterial(new Material(material));
                hexRenderer.DrawMesh();

                tile.transform.SetParent(transform);
                tile.transform.localPosition = GetPositionForHexFromCoordinate(new Vector2Int(x, y));

                HexGrid grid = tile.AddComponent<HexGrid>();
                grid.render = hexRenderer;
                grids[y, x] = grid;
            }
        }
    }

    private Vector3 GetPositionForHexFromCoordinate(Vector2Int coordinate)
    {
        int column = coordinate.x;
        int row = coordinate.y;
        float width;
        float height;
        float xPosition;
        float yPosition;
        bool shouldOffset;
        float horizontalDistance;
        float verticalDistance;
        float offset;
        float size = outerSize;
        
        if (!isFlatTopped)
        {
            shouldOffset = (row % 2) == 0;
            width = MathF.Sqrt(3f) * size;
            height = 2f * size;

            horizontalDistance = width;
            verticalDistance = height * (3f / 4f);

            offset = shouldOffset ? width / 2f : 0f;

            xPosition = column * horizontalDistance + offset;
            yPosition = row * verticalDistance;
        }
        else
        {
            shouldOffset = (column % 2) == 0;
            width = 2f * size;
            height = MathF.Sqrt(3f) * size;

            horizontalDistance = width * (3f / 4f);
            verticalDistance = height;

            offset = shouldOffset ? height / 2f : 0f;

            xPosition = column * horizontalDistance;
            yPosition = row * verticalDistance - offset;
        }

        return new Vector3(xPosition + padding.x * coordinate.x, 0, -yPosition + padding.y * coordinate.y);
    }
    private Vector2Int GetHexGridIndexByPosition(Vector3 position)
    {
        Vector2Int result = Vector2Int.zero;

        return result;
    }

    public HexGrid GetHexGridByPosition(Vector3 position)
    {
        Vector2Int index = GetHexGridIndexByPosition(position);

        return grids[index.y, index.x];
    }

    public HexGrid GetUseableHexGrid()
    {
        for(int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                if (grids[y, x].ArrangementObject == null)
                    return grids[y, x];
            }
        }

        return null;
    }
}
