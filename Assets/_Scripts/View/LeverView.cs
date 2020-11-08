using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverView : InteractableObject
{
    [SerializeField] private Lever _lever;
    [SerializeField] private Image _leverImage;

    [Header("Lever State")]
    [SerializeField]private Sprite _upSprite;
    [SerializeField]private Sprite _downSprite;
    [SerializeField]private Sprite _brokeSprite;

    protected override void InteractionAction()
    {
        foreach (var room in _lever.RoomToSwitch)
        {
            HouseState.Instance.GetRoomState(room).isLighting = !HouseState.Instance.GetRoomState(room).isLighting;
        }

        _leverImage.sprite = _leverImage.sprite == _upSprite ? _downSprite : _upSprite;
    }

    private void OnEnable()
    {
        if (_lever == null)
            return;

        if (!HouseState.Instance.GetLeverState(_lever).IsWork)
            _leverImage.sprite = _brokeSprite;
    }

    protected override bool CanBeInteracted()
    {
        return HouseState.Instance.GetLeverState(_lever).IsWork;
    }
}
