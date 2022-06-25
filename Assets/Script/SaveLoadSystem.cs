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
            player.MaxPlayerOxygen = PlayerPrefs.GetInt("MaxPlayerOxygen");
            player.MaxPlayerHealth = PlayerPrefs.GetInt("MaxPlayerHealth");
            player.MiningSpeed = PlayerPrefs.GetFloat("MiningSpeed");

        }
        else
        {
            player.MaxPlayerOxygen = 100;
            player.MaxPlayerHealth = 100;
            player.PlayerOxygen = 100;
            player.PlayerHealth = 100;
            PlayerPrefs.SetInt("MaxPlayerHealth", player.MaxPlayerHealth);
            PlayerPrefs.SetInt("MaxPlayerOxygen", player.MaxPlayerOxygen);
            player.MiningSpeed = 0.3f;
            PlayerPrefs.SetFloat("MiningSpeed", player.MiningSpeed);
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
