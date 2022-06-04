using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBaseScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) //Checking if the player is at base
    {
        if(other == player.boxCollider) //Checking what object triggered the collider and if it is player, changing bool
        {
            player.PlayerIsAtBase = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) //Checking if the player left base
    {
        if (other == player.boxCollider) //Checking what object triggered the collider and if it is player, changing bool
        {
            player.PlayerIsAtBase = false;
            Debug.Log("jigersokfuckniggers");
        }
    }
}
