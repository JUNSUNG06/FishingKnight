using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshTest : MonoBehaviour
{
    private MeshFilter filter;
    private Mesh mesh;

    private List<Color> colors;

    private void Start()
    {
        filter = GetComponent<MeshFilter>();
        mesh = filter.mesh;

        colors = new List<Color>();
        for (int i = 0; i < mesh.vertices.Length; i++)
            colors.Add(Color.red);
    }

    private void Update()
    {
        mesh.SetColors(colors);
    }
}
