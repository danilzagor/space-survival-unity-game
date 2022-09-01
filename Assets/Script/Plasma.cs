using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plasma : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1.1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (player.PlayerHealth > 0)
            {
                player.PlayerHealth -=15- (int)(15 * (CraftingSystem.LevelOfArmor * 0.1));
                EventManager.PlayerTakeDamage();
            }
        }
        Destroy(gameObject);
    }
}