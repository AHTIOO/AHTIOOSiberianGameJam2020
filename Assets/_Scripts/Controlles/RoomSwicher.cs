﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RoomSwicher : MonoBehaviour
{
    public Room InitialRoom;
    public GameObject RoomParent;

    [Header("Transition Parameters")]
    [SerializeField] private CanvasGroup _transitionScreen;
    [SerializeField] private float _transitionSpeed = 0.15f;
    [SerializeField] private RoomTransitionEffect _transitionEffect;


    private RoomView _currentRoomView;
    private Room _curentRoom;

    private Sequence _transitionSequence;

    private void Awake()
    {
        CreateRoom(InitialRoom);
    }

    public void GoToRoom(int goesToRoom)
    {
        _transitionSequence?.Kill();
        _transitionSequence = DOTween.Sequence();

        _transitionScreen.blocksRaycasts = true;
        _transitionSequence.Append(_transitionScreen.DOFade(1, _transitionSpeed));
        _transitionSequence.AppendCallback(() =>
        {
            Room roomToGo = _curentRoom.ConnectedRoom[goesToRoom];
            Destroy(_currentRoomView.gameObject);

            CreateRoom(roomToGo);
        });

        _transitionSequence.Append(_transitionEffect.DoTransition());
        _transitionSequence.Append(_transitionScreen.DOFade(0, _transitionSpeed));
        _transitionSequence.AppendCallback(() =>
        {
            _transitionScreen.blocksRaycasts = false;
            GameTimeHolder.Instance.IncreaseTime(GameTimeHolder.Instance.RoomTimeCost);
        });
    }

    private void CreateRoom(Room newRoom)
    {
        _curentRoom = newRoom;
        _currentRoomView = Instantiate(_curentRoom.RoomPrefab, RoomParent.transform);
        _currentRoomView.Initialize();

        _currentRoomView.OnRoomSwitchClick += GoToRoom;
    }
}

