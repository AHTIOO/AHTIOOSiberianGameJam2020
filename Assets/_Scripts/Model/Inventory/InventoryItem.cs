using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Inventory/Item", fileName = "InventoryItem")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] private string _itemName;
    [TextArea]
    [SerializeField] private string _itemDescription;

    public string ItemName => _itemName;

    public string ItemDescription => _itemDescription;
}
