using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorCube : Interactables
{
    MeshRenderer mesh;
    public Color[] colors;
    private int colorIndex;
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = Color.red;
    }

    protected override void interact()
    {
        colorIndex++;
        if (colorIndex >= colors.Length - 1)
        {
            colorIndex = 0;
        }
        mesh.material.color = colors[colorIndex];
    }
}
