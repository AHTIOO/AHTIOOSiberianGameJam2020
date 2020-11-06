using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RoomSwitchButton : MonoBehaviour
{
    public Action<int> OnSwitchClick = i => { };

    [SerializeField] private int _roomIndex;

    private Button _button;

    public void Initialize()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SwitchRoom);
    }

    private void SwitchRoom()
    {
        OnSwitchClick.Invoke(_roomIndex);
    }

    private void OnDestroy()
    {
        _button.onClick.AddListener(SwitchRoom);
    }
}
