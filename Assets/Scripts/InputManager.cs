using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//For Unity's new input system, this manages and links all the buttons pressed to the approriate functions in each respective class
public class NewBehaviourScript : MonoBehaviour
{
    private PlayerInput playerInput; //calls all classes
    private PlayerInput.OnFootActions onFoot;
    private playerMotor motor;
    private PlayerLook look;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput(); //Actually intailizes all classes used
        onFoot = playerInput.onFoot;
        motor = GetComponent<playerMotor>();
        look = GetComponent<PlayerLook>();
        onFoot.Jump.performed += ctx => motor.jump(); //Since this needs to only happen when preformed by the user, it only points to the function when needed
                                                      //Instead of checking for the function at all times
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Tell the player motor to move from our movement action 
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        //Tells the look to move based on the movement picked up from our look action
        look.processLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable() //This enables our Input manager
    {
        onFoot.Enable();
    }

    private void OnDisable() //This disables it
    {
        onFoot.Disable(); 
    }
}
