using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipRoomTransition : TooltipBase
{
    private const string RoomLightOn = "Эта комната освещена";
    private const string RoomLightOff = "В этой комнате нет света";

    [SerializeField] private Room _room;

    private  string RoomTransitionText => $"Перейти {_room.RoomNameForTransition.ToString()}. \n{(IsLightOn ? RoomLightOn : RoomLightOff)}";

    private bool IsLightOn => HouseState.Instance.GetRoomState(_room).isLighting;

    protected override void UpdateTooltipMessage()
    {
        tooltipView.SetTooltipText(RoomTransitionText);
    }
}
