using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactables
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void interact()
    {
        Debug.Log("Interacted with " + gameObject.name);

    }
}
