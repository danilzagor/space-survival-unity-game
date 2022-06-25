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
    public InventoryItemData[] referenceItem;
    public InventorySystem InventorySystem;
    public SavingInv savingInv ;
    public GameObject SlotPrefab;
    public GameObject Inventory;
    [SerializeField] private GameObject CraftingProcess;
    [SerializeField] private Text[] NumberOfItemsForCraft = new Text[13];

    private void Start()
    {
        
        savingInv.InventoryForSaving = new int[16];
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
    public void CraftCopperIgnot()
    {
        if (player.CoperOre >= 1)
        {
            player.CoperOre--;
            CraftItem(referenceItem[1], 1,1,3f);
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
        Debug.Log("asd2");
        if (InventorySystem.m_itemDictionary.TryGetValue(referenceItem[2], out InventoryItem value)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[3], out InventoryItem value1)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[7], out InventoryItem value2)
            && InventorySystem.m_itemDictionary.TryGetValue(referenceItem[8], out InventoryItem value3))
        {
            Debug.Log(player.MaxPlayerHealth);
            if (value.stackSize >= 10 && value1.stackSize >= 10 && value2.stackSize >= 2
                && value3.stackSize >= 2 && player.MaxPlayerHealth == 100)
            {
                Debug.Log("asd");
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
        using StreamWriter writer = new StreamWriter("Zamahaeva.json");
        writer.Write(json);
    }
    private void InventoryLoading()
    {
        using StreamReader reader = new StreamReader("Zamahaeva.json");
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
        Debug.Log(savingInv.InventoryForSaving[b]);
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
        CraftingProcess.SetActive(true);
        yield return new WaitForSeconds(Time);
        for (var i = Inventory.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(Inventory.transform.GetChild(i).gameObject);

        }
        LoadingItems(referenceItem, a, b);
        InventorySaving();
        CraftingProcess.SetActive(false);
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
        CraftingProcess.SetActive(true);
        yield return new WaitForSeconds(Time);
        if (Type == 0)
        {
            player.MiningSpeed = 0.7f;
            PlayerPrefs.SetFloat("MiningSpeed", player.MiningSpeed);
        }
        else if(Type == 1)
        {
            player.MaxPlayerOxygen = 125;
            PlayerPrefs.SetInt("MaxPlayerOxygen", player.MaxPlayerOxygen);
        }
        else if (Type == 2)
        {
            player.MaxPlayerHealth = 125;
            PlayerPrefs.SetInt("MaxPlayerHealth", player.MaxPlayerHealth);
            player.PlayerHealth = 125;
        }
        
        CraftingProcess.SetActive(false);
    }
    private void FixedUpdate()
    {
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
    }
}
