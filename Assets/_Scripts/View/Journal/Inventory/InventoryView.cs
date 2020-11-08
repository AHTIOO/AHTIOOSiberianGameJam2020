using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventoryItemView _prefab;
    [SerializeField] private Transform _pageOne;
    [SerializeField] private Transform _pageTwo;

    private List<InventoryItemView> _inventoryItemViews = new List<InventoryItemView>();

    private int _maxAmountOfItemsOnPage = 5;

    private void OnEnable()
    {
        Debug.Log("!!!");
        SetInventoryView();
    }

    private void SetInventoryView()
    {
        var inv = Inventory.Instance.CurrentItems;
        _pageOne.Clear();
        _pageTwo.Clear();
        _inventoryItemViews.Clear();

        for (int i = 0; i < inv.Count; i++)
        {
            Transform parent = i <= _maxAmountOfItemsOnPage ? _pageOne : _pageTwo;

            var view = Instantiate(_prefab, _pageOne);
            view.SetItem(inv[i]);
            _inventoryItemViews.Add(view);
        }
    }
}
