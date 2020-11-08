using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private List<InventoryItem> _initialItems = new List<InventoryItem>();

    public readonly List<InventoryItem> CurrentItems = new List<InventoryItem>();
    private List<inventoryData> ItemsHistory = new List<inventoryData>();

    class inventoryData
    {
        public InventoryItem Iteam;
        public bool isRemoved;

        public inventoryData(InventoryItem iteam, bool isRemoved)
        {
            Iteam = iteam;
            this.isRemoved = isRemoved;
        }
    }
    public void Add(InventoryItem item)
    {
        CurrentItems.Add(item);
        ItemsHistory.Add(new inventoryData(item, false));
    }

    public void AddList(List<InventoryItem> items)
    {
        foreach (var item in items)
        {
            Add(item);
        }
    }

    public void Remove(InventoryItem item)
    {
        int i;
        if (CurrentItems.Remove(item))
        {
            ItemsHistory.Find(x => x.Iteam == item).isRemoved = true;
        }
    }

    public void RemoveList(List<InventoryItem> items)
    {
        foreach (var item in items)
        {
            Remove(item);
        }
    }

    public bool InventoryHadItem(InventoryItem item)
    {
        return CurrentItems.Contains(item);
    }

    public bool InventoryHadItems(IEnumerable<InventoryItem> items)
    {
        bool result = true;

        foreach (var item in items)
        {
            if (!CurrentItems.Contains(item))
            {
                result = false;
                break;
            }
        }

        return result;
    }
}
