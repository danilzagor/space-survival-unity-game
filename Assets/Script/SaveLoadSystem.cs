using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadSystem : MonoBehaviour
{
    void Awake()
    {
        player.IronOre = PlayerPrefs.GetInt("IronOre");
        player.CoperOre = PlayerPrefs.GetInt("CoperOre");
        player.PlayerHealth = PlayerPrefs.GetInt("PlayerHealth");
        player.PlayerOxygen = PlayerPrefs.GetInt("PlayerOxygen");
    }
    void Update()
    {
        PlayerPrefs.SetInt("IronOre", player.IronOre);
        PlayerPrefs.SetInt("CoperOre", player.CoperOre);
        PlayerPrefs.SetInt("PlayerHealth", player.PlayerHealth);
        PlayerPrefs.SetInt("PlayerOxygen", player.PlayerOxygen);
    }
}
