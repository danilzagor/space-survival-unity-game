using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveLoadSystem : MonoBehaviour
{
    void Awake()
    {
        if(Menu.IsNewGame==0)
        {
            player.IronOre = PlayerPrefs.GetInt("IronOre");
            player.CoperOre = PlayerPrefs.GetInt("CoperOre");
            player.PlayerHealth = PlayerPrefs.GetInt("PlayerHealth");
            player.PlayerOxygen = PlayerPrefs.GetInt("PlayerOxygen");
        }

    }
    void Update()
    {
        PlayerPrefs.SetInt("IronOre", player.IronOre);
        PlayerPrefs.SetInt("CoperOre", player.CoperOre);
        PlayerPrefs.SetInt("PlayerHealth", player.PlayerHealth);
        PlayerPrefs.SetInt("PlayerOxygen", player.PlayerOxygen);
    }
}
