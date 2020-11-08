using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour
{
    [SerializeField] private Text _itemName;
    [SerializeField] private Text _itemDescription;

    public void SetItem(InventoryItem item)
    {
        _itemName.text = item.ItemName;
        _itemDescription.text = item.ItemDescription;
    }
}
