using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public InventoryItemData referenceItem;
    public InventorySystem InventorySystem;
    public GameObject SlotPrefab;
    public GameObject Inventory;
    [SerializeField] private GameObject g;
    public void CraftItem()
    {
        
        InventorySystem.Add(referenceItem);
        
        for (var i = g.transform.childCount - 1; i >= 0; i--)
        {
            Object.Destroy(g.transform.GetChild(i).gameObject);
        }
        foreach (InventoryItem item in InventorySystem.inventory)
        {
            GameObject obj = Instantiate(SlotPrefab);
            obj.transform.SetParent(Inventory.transform,false);
            Debug.Log(obj);
            UIInventorySlot slot = obj.GetComponent<UIInventorySlot>();
            slot.Set(item);
            Debug.Log("Set");
        }
    }
}
