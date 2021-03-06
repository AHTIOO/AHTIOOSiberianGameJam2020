﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RoomSwitchButton : InteractableObject
{
    public Action<int> OnSwitchClick = i => { };

    [SerializeField] private int _roomIndex;

    protected override void InteractionAction()
    {
        AudioManager.Instance.PlaySound(_successClip);
        OnSwitchClick.Invoke(_roomIndex);
    }
}
