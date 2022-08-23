using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    [SerializeField] GameObject CraftingButton;
    [SerializeField] GameObject EquipmentButton;
    [SerializeField] GameObject MedblockButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.boxCollider) 
        {
            CraftingButton.SetActive(true);
            EquipmentButton.SetActive(true);
            MedblockButton.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other == player.boxCollider) 
        {
            CraftingButton.SetActive(false);
            EquipmentButton.SetActive(false);
            MedblockButton.SetActive(false);
        }
    }
    public void UseMedBlock()
    {
        player.PlayerHealth = player.MaxPlayerHealth;
    }
}
