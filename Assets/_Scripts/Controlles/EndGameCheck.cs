using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameCheck : MonoBehaviour
{
    [SerializeField]private List<InventoryItem> _winIteamList;
    private bool _isGameEnded = false;

    private void Awake()
    {
        Inventory.Instance.OnGameInventoryChanged += CheckEndInventory;
        GameTimeHolder.Instance.OnGameTimeChanged += CheckEndTime;
    }
    void CheckEndTime(GameTime time)
    {
         if(time == GameTimeHolder.Instance.EndGameTime)
        {
            _isGameEnded = true;
        }
         else
        {
            _isGameEnded = false;
        }
    }

    void CheckEndInventory(List<InventoryItem> curentInventory)
    {
        int i = 0;
        foreach (InventoryItem item in _winIteamList)
        {
            if (curentInventory.Contains(item))
            {
                i++;
            }
        }
        if (i == _winIteamList.Count)
            _isGameEnded = true;
        else
            _isGameEnded = false;
    }
    public bool EndGame()
    {
        return _isGameEnded;
    }
}
