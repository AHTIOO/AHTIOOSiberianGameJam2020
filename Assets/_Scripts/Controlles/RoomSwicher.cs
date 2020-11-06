using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RoomSwicher : MonoBehaviour
{
    public Room InitialRoom;

    public CanvasGroup transitionScreen;
    public float transitionSpeed = 0.012f;
    public GameObject RoomParent;

    private RoomView _currentRoomView;
    private Room _curentRoom;

    private void Awake()
    {
        CreateRoom(InitialRoom);
    }

    public void GoToRoom(int goesToRoom)
    {
        transitionScreen.DOFade(1, transitionSpeed);
        Room roomToGo = _curentRoom.ConnectedRoom[goesToRoom];
        Destroy(_currentRoomView.gameObject);

        CreateRoom(roomToGo);

        transitionScreen.DOFade(0, transitionSpeed);
    }

    private void CreateRoom(Room newRoom)
    {
        _curentRoom = newRoom;
        _currentRoomView = Instantiate(_curentRoom.RoomPrefab, RoomParent.transform);
        _currentRoomView.Initialize();

        _currentRoomView.OnRoomSwitchClick += GoToRoom;
    }
}

