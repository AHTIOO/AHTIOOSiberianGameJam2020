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
        DialogManager.Instance.CurentDialogBegin += DeactivateDialogButtons;
        DialogManager.Instance.CurentDialogEnds += ActivateDialogButtons;

        _roomSwitchButtons = GetComponentsInChildren<RoomSwitchButton>(true).ToList();
        _dialogActivator.SetAmountOfButtons(HouseState.Instance.GetRoomState(room).CharactersOnLocations);

        _dialogActivator.OnTalkClicked += InitDialog;

        foreach (var button in _roomSwitchButtons)
        {
            button.OnSwitchClick += SwitchRoom;
        }
    }

    public void UpdateRoom(Room room)
    {
        _dialogActivator.SetAmountOfButtons(HouseState.Instance.GetRoomState(room).CharactersOnLocations);
    }

    private void DeactivateDialogButtons()
    {
        _dialogActivator.gameObject.SetActive(false);
    }

    private void ActivateDialogButtons()
    {
        _dialogActivator.gameObject.SetActive(true);
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
