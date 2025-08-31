using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinLose : MonoBehaviour
{
    public GameObject player;
    private Vector3 respawn = new Vector3(0f, 0.33f, 0f);
    private float playerHealth;
    private CharacterController controller;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = this.gameObject;
      
      
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth = player.GetComponent<PlayerHealth>().health;//Constantly checks player health to make sure they are not dead
        if (playerHealth <= 0) //If the player dies, triggers a respawn
        {
            Respawn();
        }

    }
    
  

    private void Respawn()
    {
        controller.enabled = false; //Disables the controller allowing the player to be teleported back to the spawn location
        player.transform.position = respawn;//Teleports player
        controller.enabled = true; // Turns controller back on
        player.GetComponent<PlayerHealth>().restorehealth(100f); //Restores player health
    }

   
}
