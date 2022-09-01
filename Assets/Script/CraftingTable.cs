using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    [SerializeField] GameObject[] Objects;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == player.boxCollider) 
        {
            for(int i = 0; i < Objects.Length; i++)
            {
                if (CraftingSystem.LevelOfBase == 0)
                {
                    if (i < 4)
                    {
                        Objects[i].SetActive(true);
                    } else Objects[i].SetActive(false);
                }else
                if (CraftingSystem.LevelOfBase >= 1)
                {
                    if (i >= 3)
                    {
                        Objects[i].SetActive(true);
                    }
                    else Objects[i].SetActive(false);
                }
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other == player.boxCollider)
        {
            
                for (int i = 0; i < Objects.Length; i++)
                {                   
                        Objects[i].SetActive(false);                     
                }                  
        }
        
    }
    public void UseMedBlock()
    {
        player.PlayerHealth = player.MaxPlayerHealth;
    }
}
