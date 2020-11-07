using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInInventoryCondition : InteractionCondition
{
    [SerializeField] private List<InventoryItem> _nessesaryItems = new List<InventoryItem>();

    protected override bool IsInteractable()
    {
        if (Inventory.Instance.InventoryHadItems(_nessesaryItems))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
