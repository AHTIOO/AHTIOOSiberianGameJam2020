using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomView : MonoBehaviour
{
    public Action<int> OnRoomSwitchClick = i => { };

    private List<RoomSwitchButton> _roomSwitchButtons;

    public void Initialize()
    {
        _roomSwitchButtons = GetComponentsInChildren<RoomSwitchButton>().ToList();

        foreach (var button in _roomSwitchButtons)
        {
            button.Initialize();
            button.OnSwitchClick += SwitchRoom;
        }
    }

    private void SwitchRoom(int roomIndex)
    {
        OnRoomSwitchClick.Invoke(roomIndex);
    }

    private void OnDestroy()
    {
        foreach (var button in _roomSwitchButtons)
        {
            button.OnSwitchClick -= SwitchRoom;
        }
    }
}
