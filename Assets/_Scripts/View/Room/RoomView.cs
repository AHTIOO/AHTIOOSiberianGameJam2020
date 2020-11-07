using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomView : MonoBehaviour
{
    public Action<int> OnRoomSwitchClick = i => { };
    public Action<int> OnCharacterTalkClick = i => { };

    [SerializeField] private DialogActivator _dialogActivator;

    private List<RoomSwitchButton> _roomSwitchButtons;

    public void Initialize(Room room)
    {
        _roomSwitchButtons = GetComponentsInChildren<RoomSwitchButton>().ToList();
        _dialogActivator.SetAmountOfButtons(HouseState.Instance.GetRoomState(room).CharactersOnLocations.Count);

        _dialogActivator.OnTalkClicked += InitDialog;

        foreach (var button in _roomSwitchButtons)
        {
            button.OnSwitchClick += SwitchRoom;
        }
    }

    private void InitDialog(int index)
    {
        OnCharacterTalkClick.Invoke(index);
    }

    private void SwitchRoom(int roomIndex)
    {
        OnRoomSwitchClick.Invoke(roomIndex);
    }

    private void OnDestroy()
    {
        _dialogActivator.OnTalkClicked -= InitDialog;
        foreach (var button in _roomSwitchButtons)
        {
            button.OnSwitchClick -= SwitchRoom;
        }
    }
}
