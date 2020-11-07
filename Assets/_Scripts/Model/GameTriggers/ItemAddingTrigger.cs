using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Triggers/ItemAddingTrigger")]
public class ItemAddingTrigger : GameTrigger
{
    [SerializeField] private List<InventoryItem> _items = new List<InventoryItem>();

    public override void ActivateTrigger()
    {
        Inventory.Instance.AddList(_items);
    }
}
