using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{

    public Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }
    private void Awake()
    {
        inventory = new List<InventoryItem>();

        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }
    public InventoryItem Get(InventoryItemData referenceData)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            return value;
        }
        return null;
    }
    public void Add(InventoryItemData referenceData, int a)
    {
        
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {

            value.AddToStack(a);
        }
        else
        {
            InventoryItem newItem = new InventoryItem(referenceData,a);
            inventory.Add(newItem);

            m_itemDictionary.Add(referenceData, newItem);
        }

    }
    public void Remove(InventoryItemData referenceData, int a)
    {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack(a);
            if (value.stackSize<1)
            {   

                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
            }    
        }

    }
    
}
