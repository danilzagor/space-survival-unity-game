using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

[Serializable]
public class SavingInv
{
     public int[] InventoryForSaving;
}
public class CraftingSystem : MonoBehaviour
{
    [SerializeField] GameObject[] Upgrades;
    public InventoryItemData[] referenceItem;
    public InventorySystem InventorySystem;
    public SavingInv savingInv ;
    public GameObject SlotPrefab;
    public GameObject Inventory;
    public static int LevelOfDrill=1;
    public static int LevelOfArmor=1;
    [SerializeField] private GameObject CraftingProcess;
    [SerializeField] private Text[] NumberOfItemsForCraft = new Text[13];
    private float DelayForCrafting;
    private float DelayForEquipment;

    private void Start()
    {
        savingInv.InventoryForSaving = new int[25];
        InventoryLoading();       
    }
    public void CraftIronIgnot()
    {
        if (player.IronOre >= 1)
        {
            player.IronOre--;
            CraftItem(referenceItem[0],1,0,3f);

        }
    }
    public void CraftTitaniumIgnot()
    {
        if (player.TitaniumOre >= 1)
        {
            player.TitaniumOre--;
            CraftItem(referenceItem[9], 1, 9, 3f);


        }
    }
    public void CraftGoldenIgnot()
    {
        if (player.GoldOre >= 1)
        {
            player.GoldOre--;
            CraftItem(referenceItem[10], 1, 10, 3f);


        }
    }
    public void CraftCopperIgnot()
    {
        if (player.CoperOre >= 1)
        {
            player.CoperOre--;
            CraftItem(referenceItem[1], 1,1,3f);
        }
    }
    public void CraftGoldenDust()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[10], out InventoryItem value))
        {
            if (value.stackSize >= 1)
            {
                InventorySystem.Remove(referenceItem[10], 1);
                savingInv.InventoryForSaving[10] -= 1;
                CraftItem(referenceItem[13], 2, 13, 2f);

            }

        }
    }
    public void CraftIronPlate()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[0], out InventoryItem value))
        {
            if (value.stackSize >= 1)
            {
                InventorySystem.Remove(referenceItem[0], 1);
                savingInv.InventoryForSaving[0] -= 1;
                CraftItem(referenceItem[2],1,2,2f);
                
            }

        }
    }
    public void CraftCopperPlate()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[1], out InventoryItem value))
        {
            if (value.stackSize >= 1)
            {
                InventorySystem.Remove(referenceItem[1], 1);
                savingInv.InventoryForSaving[1] -= 1;
                CraftItem(referenceItem[3], 1,3,2f);
            }

        }
    }
    public void CraftTitaniumPlate()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[9], out InventoryItem value))
        {
            if (value.stackSize >= 1)
            {
                InventorySystem.Remove(referenceItem[9], 1);
                savingInv.InventoryForSaving[9] -= 1;
                CraftItem(referenceItem[11], 1, 11, 2f);
            }

        }
    }
    public void CraftGoldenPlate()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[10], out InventoryItem value))
        {
            if (value.stackSize >= 1)
            {
                InventorySystem.Remove(referenceItem[10], 1);
                savingInv.InventoryForSaving[10] -= 1;
                CraftItem(referenceItem[12], 1, 12, 2f);
            }

        }
    }
    public void CraftSemiconductor()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[13], out InventoryItem value))
        {
            if (value.stackSize >= 1 && player.CoalOre>=1)
            {
                player.CoalOre--;
                InventorySystem.Remove(referenceItem[13], 1);
                savingInv.InventoryForSaving[13] -= 1;
                CraftItem(referenceItem[16], 1, 16, 3f);
            }

        }
    }
    public void CraftAmmo()
    {

        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[2], out InventoryItem value))
        {
            if (player.CoalOre >= 1 && value.stackSize >= 2)
            {
                InventorySystem.Remove(referenceItem[2], 2);
                savingInv.InventoryForSaving[2] -= 2;
                player.CoalOre -= 1;
                StartCoroutine(EquipmentCoroutine(2f, 6));

            }
        }
        
    }
    public void CraftMedicine()
    {

        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[2], out InventoryItem value) && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[3], out InventoryItem value1))
        {
            if (value.stackSize >= 1 && value1.stackSize >= 1 && player.AlienRemains >= 3 && player.Medicine<3)
            {
                InventorySystem.Remove(referenceItem[2], 1);
                savingInv.InventoryForSaving[2] -= 1;
                InventorySystem.Remove(referenceItem[3], 1);
                savingInv.InventoryForSaving[3] -= 1;
                player.AlienRemains -= 3;
                StartCoroutine(EquipmentCoroutine(10f, 7));
            }

        }

    }
    public void CraftIronBar()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[0], out InventoryItem value))
        {
            if (value.stackSize >= 1)
            {
                InventorySystem.Remove(referenceItem[0], 1);
                savingInv.InventoryForSaving[0] -= 1;
                CraftItem(referenceItem[4], 2,4, 2f);
            }

        }
    }
    public void CraftCopperWire()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[3], out InventoryItem value))
        {
            if (value.stackSize >= 1)
            {
                InventorySystem.Remove(referenceItem[3], 1);
                savingInv.InventoryForSaving[3] -= 1;
                CraftItem(referenceItem[5], 2,5, 2f);
            }

        }
    }
    public void CraftIronBeam()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[2], out InventoryItem value) && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[4], out InventoryItem value1))
        {
            if (value.stackSize >= 2 && value1.stackSize >= 4)
            {
                InventorySystem.Remove(referenceItem[2], 2);
                savingInv.InventoryForSaving[2] -= 2;
                InventorySystem.Remove(referenceItem[4], 4);
                savingInv.InventoryForSaving[4] -= 4;
                CraftItem(referenceItem[6], 1,6, 5f);
            }

        }
    }
    public void CraftChip()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[2], out InventoryItem value) && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[5], out InventoryItem value1))
        {
            if (value.stackSize >= 1 && value1.stackSize >= 4)
            {
                InventorySystem.Remove(referenceItem[2], 1);
                savingInv.InventoryForSaving[2] -= 1;
                InventorySystem.Remove(referenceItem[5], 4);
                savingInv.InventoryForSaving[5] -= 4;
                CraftItem(referenceItem[7], 1,7, 10f);
            }

        }
    }
    public void CraftMotor()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[2], out InventoryItem value) 
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[5], out InventoryItem value1) 
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[4], out InventoryItem value2))
        {
            if (value.stackSize >= 2 && value1.stackSize >= 2 && value2.stackSize >= 1)
            {
                InventorySystem.Remove(referenceItem[2], 1);
                savingInv.InventoryForSaving[2] -= 1;
                InventorySystem.Remove(referenceItem[5], 2);
                savingInv.InventoryForSaving[5] -= 2;
                InventorySystem.Remove(referenceItem[4], 1);
                savingInv.InventoryForSaving[4] -= 1;
                CraftItem(referenceItem[8], 1,8, 20f);
            }

        }
    }
    public void CraftChipLvl2()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[7], out InventoryItem value)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[16], out InventoryItem value1)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[5], out InventoryItem value2)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[12], out InventoryItem value3))
        {
            if (value.stackSize >= 1 && value1.stackSize >= 5 && value2.stackSize >= 5 && value3.stackSize >= 1 )
            {
                InventorySystem.Remove(referenceItem[7], 1);
                savingInv.InventoryForSaving[7] -= 1;
                InventorySystem.Remove(referenceItem[16], 5);
                savingInv.InventoryForSaving[16] -= 5;
                InventorySystem.Remove(referenceItem[5], 5);
                savingInv.InventoryForSaving[5] -= 5;
                InventorySystem.Remove(referenceItem[12], 1);
                savingInv.InventoryForSaving[12] -= 1;
                CraftItem(referenceItem[14], 1, 14, 60f);
            }

        }
    }
    public void CraftMotorLvl2()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[8], out InventoryItem value)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[16], out InventoryItem value1)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[11], out InventoryItem value2)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[13], out InventoryItem value3))
        {
            if (value.stackSize >= 1 && value1.stackSize >= 2 && value2.stackSize >= 2 && value3.stackSize >= 4)
            {
                InventorySystem.Remove(referenceItem[8], 1);
                savingInv.InventoryForSaving[8] -= 1;
                InventorySystem.Remove(referenceItem[16], 2);
                savingInv.InventoryForSaving[16] -= 2;
                InventorySystem.Remove(referenceItem[11], 2);
                savingInv.InventoryForSaving[11] -= 2;
                InventorySystem.Remove(referenceItem[13], 4);
                savingInv.InventoryForSaving[13] -= 4;
                CraftItem(referenceItem[15], 1, 15, 60f);
            }

        }
    }
    public void CraftDrillLvl2()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[2], out InventoryItem value)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[3], out InventoryItem value1)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[7], out InventoryItem value2)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[8], out InventoryItem value3))
        {
            if (value.stackSize >= 5 && value1.stackSize >= 5 && value2.stackSize >= 1 && value3.stackSize >= 2 && player.MiningSpeed==0.3f)
            {
                InventorySystem.Remove(referenceItem[2], 5);
                savingInv.InventoryForSaving[2] -= 5;
                InventorySystem.Remove(referenceItem[3], 5);
                savingInv.InventoryForSaving[3] -= 5;
                InventorySystem.Remove(referenceItem[7], 1);
                savingInv.InventoryForSaving[7] -= 1;
                InventorySystem.Remove(referenceItem[8], 2);
                savingInv.InventoryForSaving[8] -= 2;
                StartCoroutine(EquipmentCoroutine(60f, 0));
            }

        }
    }
    public void CraftDrillLvl3()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[4], out InventoryItem value)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[2], out InventoryItem value1)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[3], out InventoryItem value2)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[8], out InventoryItem value3))
        {
            if (value.stackSize >= 6 && value1.stackSize >= 10 && value2.stackSize >= 10 && value3.stackSize >= 2 && LevelOfDrill != 3)
            {
                InventorySystem.Remove(referenceItem[4], 6);
                savingInv.InventoryForSaving[4] -= 6;
                InventorySystem.Remove(referenceItem[2], 10);
                savingInv.InventoryForSaving[2] -= 10;
                InventorySystem.Remove(referenceItem[3], 10);
                savingInv.InventoryForSaving[3] -= 10;
                InventorySystem.Remove(referenceItem[8], 2);
                savingInv.InventoryForSaving[8] -= 2;
                StartCoroutine(EquipmentCoroutine(120f, 3));
            }

        }
    }
    public void CraftBallonLvl3()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[11], out InventoryItem value)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[15], out InventoryItem value1)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[14], out InventoryItem value2)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[13], out InventoryItem value3))
        {
            if (value.stackSize >= 5 && value1.stackSize >= 2 && value2.stackSize >= 1 && value3.stackSize >= 10 && player.MaxPlayerOxygen == 125)
            {
                InventorySystem.Remove(referenceItem[11], 5);
                savingInv.InventoryForSaving[11] -= 5;
                InventorySystem.Remove(referenceItem[15], 2);
                savingInv.InventoryForSaving[15] -= 2;
                InventorySystem.Remove(referenceItem[14], 1);
                savingInv.InventoryForSaving[14] -= 1;
                InventorySystem.Remove(referenceItem[13], 10);
                savingInv.InventoryForSaving[13] -= 10;
                StartCoroutine(EquipmentCoroutine(120f, 4));
            }

        }
    }
    public void CraftArmorLvl3()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[11], out InventoryItem value)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[15], out InventoryItem value1)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[14], out InventoryItem value2)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[12], out InventoryItem value3))
        {
            if (value.stackSize >= 10 && value1.stackSize >= 1 && value2.stackSize >= 1 && value3.stackSize >= 10 && LevelOfArmor!=3)
            {
                InventorySystem.Remove(referenceItem[11], 10);
                savingInv.InventoryForSaving[11] -= 10;
                InventorySystem.Remove(referenceItem[15], 1);
                savingInv.InventoryForSaving[15] -= 1;
                InventorySystem.Remove(referenceItem[14], 1);
                savingInv.InventoryForSaving[14] -= 1;
                InventorySystem.Remove(referenceItem[12], 10);
                savingInv.InventoryForSaving[12] -= 10;
                StartCoroutine(EquipmentCoroutine(120f, 5));
            }

        }
    }
    public void CraftBallonLvl2()
    {
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[2], out InventoryItem value)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[3], out InventoryItem value1)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[4], out InventoryItem value2)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[8], out InventoryItem value3))
        {
            if (value.stackSize >= 5 && value1.stackSize >= 5 && value2.stackSize >= 1 
                && value3.stackSize >= 1 && player.MaxPlayerOxygen==100)
            {
                InventorySystem.Remove(referenceItem[2], 5);
                savingInv.InventoryForSaving[2] -= 5;
                InventorySystem.Remove(referenceItem[3], 5);
                savingInv.InventoryForSaving[3] -= 5;
                InventorySystem.Remove(referenceItem[4], 1);
                savingInv.InventoryForSaving[4] -= 1;
                InventorySystem.Remove(referenceItem[8], 1);
                savingInv.InventoryForSaving[8] -= 1;
                StartCoroutine(EquipmentCoroutine(60f, 1));

            }

        }
    }
    public void CraftArmorLvl2()
    {

        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[2], out InventoryItem value)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[3], out InventoryItem value1)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[7], out InventoryItem value2)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[8], out InventoryItem value3))
        {

            if (value.stackSize >= 10 && value1.stackSize >= 10 && value2.stackSize >= 2
                && value3.stackSize >= 2 && player.MaxPlayerHealth == 100)
            {

                InventorySystem.Remove(referenceItem[2], 10);
                savingInv.InventoryForSaving[2] -= 10;
                InventorySystem.Remove(referenceItem[3], 10);
                savingInv.InventoryForSaving[3] -= 10;
                InventorySystem.Remove(referenceItem[7], 2);
                savingInv.InventoryForSaving[7] -= 2;
                InventorySystem.Remove(referenceItem[8], 2);
                savingInv.InventoryForSaving[8] -= 2;
                StartCoroutine(EquipmentCoroutine(60f, 2));

            }

        }
    }
    public void CraftItem(InventoryItemData referenceItem, int a,int b,float Time)
    {
        StartCoroutine(CraftingTiming( Time, referenceItem, a, b));

    }
    private void InventorySaving()
    {
        string json = JsonUtility.ToJson(savingInv);
        using StreamWriter writer = new StreamWriter(Application.persistentDataPath + "/Zamahaeva.json");
        writer.Write(json);
    }
    private void InventoryLoading()
    {
        using StreamReader reader = new StreamReader(Application.persistentDataPath + "/Zamahaeva.json");
        string json = reader.ReadToEnd();
        SavingInv savingInv = JsonUtility.FromJson<SavingInv>(json);
        
        for(int i = 0; i < referenceItem.Length; i++)
        {
            if (savingInv.InventoryForSaving[i] > 0)
            {
                LoadingItems(referenceItem[i], savingInv.InventoryForSaving[i],i);
                
            }

        }
    }
    private void LoadingItems(InventoryItemData referenceItem, int a,int b)
    {

        for (var i = Inventory.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(Inventory.transform.GetChild(i).gameObject);

        }
        InventorySystem.Add(referenceItem, a);
        savingInv.InventoryForSaving[b] += a;
        foreach (InventoryItem item in InventorySystem.inventory)
        {

            GameObject obj = Instantiate(SlotPrefab);
            obj.transform.SetParent(Inventory.transform, false);
            UIInventorySlot slot = obj.GetComponent<UIInventorySlot>();
            slot.Set(item);
        }
    }
    IEnumerator CraftingTiming(float Time, InventoryItemData referenceItem, int a, int b)
    {
        //CraftingProcess.SetActive(false);
        DelayForCrafting += Time;
        yield return new WaitForSeconds(DelayForCrafting);
        for (var i = Inventory.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(Inventory.transform.GetChild(i).gameObject);

        }
        LoadingItems(referenceItem, a, b);
        InventorySaving();
        CraftingProcess.SetActive(false);
        DelayForCrafting -= Time;
    }
    IEnumerator EquipmentCoroutine(float Time,int Type)
    {
        for (var i = Inventory.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(Inventory.transform.GetChild(i).gameObject);

        }
        foreach (InventoryItem item in InventorySystem.inventory)
        {

            GameObject obj = Instantiate(SlotPrefab);
            obj.transform.SetParent(Inventory.transform, false);
            UIInventorySlot slot = obj.GetComponent<UIInventorySlot>();
            slot.Set(item);
        }
        DelayForEquipment += Time;
        //CraftingProcess.SetActive(false);
        yield return new WaitForSeconds(DelayForEquipment);
        DelayForEquipment -= Time;
        if (Type == 0)
        {
            player.MiningSpeed = 0.7f;
            PlayerPrefs.SetFloat("MiningSpeed", player.MiningSpeed);
            LevelOfDrill = 2;
            PlayerPrefs.SetInt("LevelOfDrill", LevelOfDrill);
        }
        else if(Type == 1)
        {
            player.MaxPlayerOxygen = 125;
            PlayerPrefs.SetInt("MaxPlayerOxygen", player.MaxPlayerOxygen);
        }
        else if (Type == 2)
        {
            PlayerPrefs.SetInt("MaxPlayerHealth", player.MaxPlayerHealth);
            LevelOfArmor = 2;
            PlayerPrefs.SetInt("LevelOfArmor", LevelOfArmor);
        }
        else if (Type == 3)
        {
            LevelOfDrill = 3;
        }
        else if (Type == 4)
        {
            player.MaxPlayerOxygen = 150;
            PlayerPrefs.SetInt("MaxPlayerOxygen", player.MaxPlayerOxygen);
        }
        else if (Type == 5)
        {
            LevelOfArmor = 3;
        }
        else if (Type == 6)
        {
            player.PlayerAmmo += 50;
        }
        else if (Type == 7)
        {
            player.Medicine += 1;
        }
        CraftingProcess.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (LevelOfArmor == 1)
        {
            Upgrades[0].SetActive(true);
            Upgrades[1].SetActive(false);
        }
        else if (LevelOfArmor == 2)
        {
            Upgrades[0].SetActive(false);
            Upgrades[1].SetActive(true);
        }else
        {
            Upgrades[0].SetActive(false);
            Upgrades[1].SetActive(false);
        }
        if (player.MaxPlayerOxygen == 100)
        {
            Upgrades[2].SetActive(true);
            Upgrades[3].SetActive(false);
        }
        else if (player.MaxPlayerOxygen == 125)
        {
            Upgrades[2].SetActive(false);
            Upgrades[3].SetActive(true);
        }
        else
        {
            Upgrades[2].SetActive(false);
            Upgrades[3].SetActive(false);
        }
        
        if (LevelOfDrill == 1)
        {
            Upgrades[4].SetActive(true);
            Upgrades[5].SetActive(false);
        }
        else if (LevelOfDrill == 2)
        {
            Upgrades[4].SetActive(false);
            Upgrades[5].SetActive(true);
        }
        else
        {
            Upgrades[4].SetActive(false);
            Upgrades[5].SetActive(false);
        }

        NumberOfItemsForCraft[0].text = player.IronOre + "/1";
        NumberOfItemsForCraft[1].text = player.CoperOre + "/1";
        NumberOfItemsForCraft[2].text = savingInv.InventoryForSaving[0] + "/1";
        NumberOfItemsForCraft[3].text = savingInv.InventoryForSaving[1] + "/1";
        NumberOfItemsForCraft[4].text = savingInv.InventoryForSaving[0] + "/1";
        NumberOfItemsForCraft[5].text = savingInv.InventoryForSaving[3] + "/1";
        NumberOfItemsForCraft[6].text = savingInv.InventoryForSaving[2] + "/2";
        NumberOfItemsForCraft[7].text = savingInv.InventoryForSaving[4] + "/4";
        NumberOfItemsForCraft[8].text = savingInv.InventoryForSaving[2] + "/1";
        NumberOfItemsForCraft[9].text = savingInv.InventoryForSaving[5] + "/4";
        NumberOfItemsForCraft[10].text = savingInv.InventoryForSaving[2] + "/2";
        NumberOfItemsForCraft[11].text = savingInv.InventoryForSaving[5] + "/2";
        NumberOfItemsForCraft[12].text = savingInv.InventoryForSaving[4] + "/1";
        NumberOfItemsForCraft[13].text = savingInv.InventoryForSaving[7] + "/1";
        NumberOfItemsForCraft[14].text = savingInv.InventoryForSaving[2] + "/5";
        NumberOfItemsForCraft[15].text = savingInv.InventoryForSaving[3] + "/5";
        NumberOfItemsForCraft[16].text = savingInv.InventoryForSaving[8] + "/2";
        NumberOfItemsForCraft[17].text = savingInv.InventoryForSaving[4] + "/1";
        NumberOfItemsForCraft[18].text = savingInv.InventoryForSaving[2] + "/5";
        NumberOfItemsForCraft[19].text = savingInv.InventoryForSaving[3] + "/5";
        NumberOfItemsForCraft[20].text = savingInv.InventoryForSaving[8] + "/1";
        NumberOfItemsForCraft[21].text = savingInv.InventoryForSaving[7] + "/2";
        NumberOfItemsForCraft[22].text = savingInv.InventoryForSaving[2] + "/10";
        NumberOfItemsForCraft[23].text = savingInv.InventoryForSaving[3] + "/10";
        NumberOfItemsForCraft[24].text = savingInv.InventoryForSaving[8] + "/2";
        NumberOfItemsForCraft[25].text = player.TitaniumOre + "/1";
        NumberOfItemsForCraft[26].text = player.GoldOre + "/1";
        NumberOfItemsForCraft[27].text = savingInv.InventoryForSaving[10] + "/1";
        NumberOfItemsForCraft[28].text = savingInv.InventoryForSaving[9] + "/1";
        NumberOfItemsForCraft[29].text = savingInv.InventoryForSaving[10] + "/1";
        NumberOfItemsForCraft[30].text = player.CoalOre + "/1";
        NumberOfItemsForCraft[31].text = savingInv.InventoryForSaving[13] + "/1";
        NumberOfItemsForCraft[32].text = savingInv.InventoryForSaving[7] + "/1";
        NumberOfItemsForCraft[33].text = savingInv.InventoryForSaving[16] + "/5";
        NumberOfItemsForCraft[34].text = savingInv.InventoryForSaving[5] + "/5";
        NumberOfItemsForCraft[35].text = savingInv.InventoryForSaving[12] + "/1";
        NumberOfItemsForCraft[36].text = savingInv.InventoryForSaving[8] + "/1";
        NumberOfItemsForCraft[37].text = savingInv.InventoryForSaving[16] + "/2";
        NumberOfItemsForCraft[38].text = savingInv.InventoryForSaving[11] + "/2";
        NumberOfItemsForCraft[39].text = savingInv.InventoryForSaving[13] + "/4";

        NumberOfItemsForCraft[40].text = savingInv.InventoryForSaving[4] + "/6";
        NumberOfItemsForCraft[41].text = savingInv.InventoryForSaving[2] + "/10";
        NumberOfItemsForCraft[42].text = savingInv.InventoryForSaving[3] + "/10";
        NumberOfItemsForCraft[43].text = savingInv.InventoryForSaving[8] + "/2";
        NumberOfItemsForCraft[44].text = savingInv.InventoryForSaving[11] + "/5";
        NumberOfItemsForCraft[45].text = savingInv.InventoryForSaving[15] + "/2";
        NumberOfItemsForCraft[46].text = savingInv.InventoryForSaving[14] + "/1";
        NumberOfItemsForCraft[47].text = savingInv.InventoryForSaving[13] + "/10";
        NumberOfItemsForCraft[48].text = savingInv.InventoryForSaving[11] + "/10";
        NumberOfItemsForCraft[49].text = savingInv.InventoryForSaving[15] + "/1";
        NumberOfItemsForCraft[50].text = savingInv.InventoryForSaving[14] + "/1";
        NumberOfItemsForCraft[51].text = savingInv.InventoryForSaving[12] + "/10";
        NumberOfItemsForCraft[52].text = player.CoalOre + "/1";
        NumberOfItemsForCraft[53].text = savingInv.InventoryForSaving[2] + "/2";

        NumberOfItemsForCraft[54].text = player.AlienRemains + "/3";
        NumberOfItemsForCraft[55].text = savingInv.InventoryForSaving[2] + "/1";
        NumberOfItemsForCraft[56].text = savingInv.InventoryForSaving[3] + "/1";
    }
}
