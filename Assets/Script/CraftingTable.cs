using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    [SerializeField] GameObject CraftingButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.boxCollider) 
        {
            CraftingButton.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other == player.boxCollider) 
        {
            CraftingButton.SetActive(false);
        }
    }

}
