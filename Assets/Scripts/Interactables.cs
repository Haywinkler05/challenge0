using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    public bool useEvents;
    public string promptMessage;
   
    public void BaseInteract()
    {
        if (useEvents)
        {
            GetComponent<interactionEvent>().onInteract.Invoke();
        }
        interact();
    }
    // Start is called before the first frame update
    protected virtual void interact()
    {

    }
}
