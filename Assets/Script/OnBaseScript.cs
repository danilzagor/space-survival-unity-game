using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBaseScript : MonoBehaviour
{
    [SerializeField] private Sprite[] baseSprite = new Sprite[2];
    [SerializeField] private SpriteRenderer currenbaseSprite;
    private void OnTriggerEnter2D(Collider2D other) //Checking if the player is at base
    {
        if(other == player.boxCollider) //Checking what object triggered the collider and if it is player, changing bool
        {
            currenbaseSprite.sprite = baseSprite[0];
            player.PlayerIsAtBase = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) //Checking if the player left base
    {
        if (other == player.boxCollider) //Checking what object triggered the collider and if it is player, changing bool
        {
            player.PlayerIsAtBase = false;
            currenbaseSprite.sprite = baseSprite[1];
        }
    }
}
