using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RoomSwicher : Singleton<RoomSwicher>
{
    public Room InitialRoom;
    public GameObject RoomParent;
    public DialogManager DialogManager;

    [SerializeField] private string _darkRoomMessage;

    [Header("Transition Parameters")]
    [SerializeField] private CanvasGroup _transitionScreen;
    [SerializeField] private float _transitionSpeed = 0.15f;
    [SerializeField] private RoomTransitionEffect _transitionEffect;
    
    private Dictionary<Room,RoomView> _roomViews = new Dictionary<Room, RoomView>();
    private Room _curentRoom;

    private Sequence _transitionSequence;

    private void Start()
    {
        foreach (var room in HouseState.Instance.GetAllRooms())
        {
            var roomView = Instantiate(room.RoomPrefab, RoomParent.transform);
            roomView.Initialize(room);
            _roomViews.Add(room, roomView);
            roomView.gameObject.SetActive(false);

            roomView.OnRoomSwitchClick += GoToRoom;
            roomView.OnCharacterTalkClick += InitializeDialog;
        }

        _curentRoom = InitialRoom;
        _roomViews[_curentRoom].gameObject.SetActive(true);
    }

    public void GoToRoom(int goesToRoom)
    {
        if (!HouseState.Instance.GetRoomState(_curentRoom.ConnectedRoom[goesToRoom].connectedRoom).isLighting)
        {
            MessegePopUp.Instance.MessegePlayer(_darkRoomMessage);
            return;
        }

        _transitionSequence?.Kill();
        _transitionSequence = DOTween.Sequence();
        
        _transitionScreen.blocksRaycasts = true;
        _transitionSequence.Append(_transitionScreen.DOFade(1, _transitionSpeed));
        _transitionSequence.AppendCallback(() =>
        {
            Room roomToGo = _curentRoom.ConnectedRoom[goesToRoom].connectedRoom;
            _roomViews[_curentRoom].gameObject.SetActive(false);

            _curentRoom = roomToGo;
            _roomViews[_curentRoom].gameObject.SetActive(true);
            _roomViews[_curentRoom].UpdateRoom(_curentRoom);
            
            Map.Instance.UpdateMap(_curentRoom);
        });

        _transitionSequence.Append(_transitionEffect.DoTransition());
        _transitionSequence.Append(_transitionScreen.DOFade(0, _transitionSpeed));
        _transitionSequence.AppendCallback(() =>
        {
            _transitionScreen.blocksRaycasts = false;
            GameTimeHolder.Instance.IncreaseTime(GameTimeHolder.Instance.RoomTimeCost);
        });
    }

    public void InitializeDialog(int characterIndex)
    {
        var character = HouseState.Instance.GetRoomState(_curentRoom).CharactersOnLocations[characterIndex];
        var characterState = HouseState.Instance.GetCharacterState(character);

        string dialog = characterState.IsAlive
            ? characterState.CurrentCharacterDefinition.Dialog
            : character.DeathDialog;

        DialogManager.Begin(dialog, character, characterState.IsAlive);
    }

    public void ForceUpdate()
    {
        _roomViews[_curentRoom].UpdateRoom(_curentRoom);
    }
}

