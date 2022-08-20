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
            player.CoalOre = PlayerPrefs.GetInt("CoalOre");
            player.GoldOre = PlayerPrefs.GetInt("GoldOre");
            player.TitaniumOre = PlayerPrefs.GetInt("TitaniumOre");
            player.AlienRemains = PlayerPrefs.GetInt("AlienRemains");
            player.PlayerHealth = PlayerPrefs.GetInt("PlayerHealth");
            player.PlayerOxygen = PlayerPrefs.GetInt("PlayerOxygen");
            player.MaxPlayerOxygen = PlayerPrefs.GetInt("MaxPlayerOxygen");
            player.MaxPlayerHealth = PlayerPrefs.GetInt("MaxPlayerHealth");
            player.MiningSpeed = PlayerPrefs.GetFloat("MiningSpeed");
            CraftingSystem.LevelOfDrill = PlayerPrefs.GetInt("LevelOfDrill");
            if (CraftingSystem.LevelOfDrill == 0)
            {
                CraftingSystem.LevelOfDrill =1;
            }
            CraftingSystem.LevelOfArmor = PlayerPrefs.GetInt("LevelOfArmor");
            if (CraftingSystem.LevelOfArmor == 0)
            {
                CraftingSystem.LevelOfArmor =1;
            }
            player.PlayerAmmo = PlayerPrefs.GetInt("PlayerAmmo");
            player.Medicine = PlayerPrefs.GetInt("Medicine");

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
            CraftingSystem.LevelOfDrill = 1;
            PlayerPrefs.SetFloat("MiningSpeed", player.MiningSpeed);
            PlayerPrefs.SetInt("LevelOfDrill", CraftingSystem.LevelOfDrill);
            CraftingSystem.LevelOfArmor = 1;
            PlayerPrefs.SetInt("LevelOfArmor", CraftingSystem.LevelOfArmor);
            player.PlayerAmmo = 100;
            player.IronOre = 0;
            player.CoperOre = 0;
            player.CoalOre = 0;
            player.TitaniumOre = 0;
            player.GoldOre = 0;
            player.AlienRemains = 0;
            player.Medicine = 0;
        }
        
    }
   
    void Update()
    {
        PlayerPrefs.SetInt("IronOre", player.IronOre);
        PlayerPrefs.SetInt("CoperOre", player.CoperOre);
        PlayerPrefs.SetInt("CoalOre", player.CoalOre);
        PlayerPrefs.SetInt("TitaniumOre", player.TitaniumOre);
        PlayerPrefs.SetInt("GoldOre", player.GoldOre);
        PlayerPrefs.SetInt("PlayerHealth", player.PlayerHealth);
        PlayerPrefs.SetInt("PlayerOxygen", player.PlayerOxygen);
        PlayerPrefs.SetInt("PlayerAmmo", player.PlayerAmmo);
        PlayerPrefs.SetInt("AlienRemains", player.AlienRemains);
        PlayerPrefs.SetInt("Medicine", player.Medicine);
    }
}
