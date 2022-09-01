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
            if (CraftingSystem.LevelOfBase == 0)
            {
                currenbaseSprite.sprite = baseSprite[0];              
            }
            else if (CraftingSystem.LevelOfBase == 1)
            {
                currenbaseSprite.sprite = baseSprite[2];
            }

            player.PlayerIsAtBase = true;
            EventManager.TriggerOnBase();
        }
        
    }
    private void OnTriggerExit2D(Collider2D other) //Checking if the player left base
    {
        if (other == player.boxCollider) //Checking what object triggered the collider and if it is player, changing bool
        {
            player.PlayerIsAtBase = false;
            if (CraftingSystem.LevelOfBase == 0)
            {
                currenbaseSprite.sprite = baseSprite[1];
            }
            else if (CraftingSystem.LevelOfBase == 1)
            {
                currenbaseSprite.sprite = baseSprite[3];
            }

        }
    }
}
