using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField] public class InventoryItem 
{
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }
    public InventoryItem(InventoryItemData source,int a)
    {
        data = source;
        AddToStack(a);
    }
    public void AddToStack(int a)
    {
        stackSize+=a;
    }
    public void RemoveFromStack(int a)
    {
        stackSize-=a;
    }
}
