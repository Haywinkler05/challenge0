using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCube : Interactables
        
{

    public GameObject particle;

    protected override void interact()
    {
        Destroy(gameObject);
        Instantiate(particle, transform.position, Quaternion.identity);
    }
}
