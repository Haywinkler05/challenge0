using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animateCube : Interactables
{
    Animator animator;
    private string startPrompt;
    public string startMessage;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startMessage = promptMessage;

    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            promptMessage = startPrompt;
        }
        else
        {
            promptMessage = "animating...";
        }
    }

        protected override void interact()
    {
        animator.Play("Spin");
    }
    }

