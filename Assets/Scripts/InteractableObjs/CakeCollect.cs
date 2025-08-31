using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakeCollect : Interactables
{
    [SerializeField]
    private GameObject cake;
    // Start is called before the first frame update
    void Start()
    {
        cake = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void interact()
    {
        cake.SetActive(false);
    }
}
