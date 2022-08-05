using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeGuyLaser : MonoBehaviour
{
    int k = 0;
    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.name == "Player")
        {
            if (k == 7)
            {
                player.PlayerHealth--;
                k = 0;
            }
            else k++;
           
        }
    }
}
