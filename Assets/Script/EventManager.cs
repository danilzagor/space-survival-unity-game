using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnBaseAction();
    public static event OnBaseAction OnBase;

    public delegate void TakeDamageAction();
    public static event TakeDamageAction TakeDamage;

    public static void TriggerOnBase()
    {
        if (player.PlayerIsAtBase)
        {
            if (OnBase != null)
                OnBase();
        }
    }
    public static void PlayerTakeDamage()
    {      
            if (TakeDamage != null)
                TakeDamage();       
    }
}
