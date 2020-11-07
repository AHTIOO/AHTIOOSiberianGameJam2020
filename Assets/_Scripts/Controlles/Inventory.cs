using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private List<InventoryItem> _initialItems = new List<InventoryItem>();

    public readonly List<InventoryItem> CurrentItems = new List<InventoryItem>();
    public readonly List<InventoryItem> RemovedItems = new List<InventoryItem>();

    public void Add(InventoryItem item)
    {
        CurrentItems.Add(item);
    }

    public void Remove(InventoryItem item)
    {
        CurrentItems.Remove(item);
        RemovedItems.Add(item);
    }
}
