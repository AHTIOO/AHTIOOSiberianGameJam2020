using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Triggers/ItemRemoving")]
public class ItemRemovingTrigger : GameTrigger
{
    [SerializeField] private List<InventoryItem> _items = new List<InventoryItem>();

    public override void ActivateTrigger()
    {
        Inventory.Instance.RemoveList(_items);
    }
}
