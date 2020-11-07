using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Inventory/Item", fileName = "InventoryItem")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] private string _itemName;

    public string ItemName => _itemName;
}
