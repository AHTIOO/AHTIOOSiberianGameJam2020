using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Triggers/RoomLightTrigger")]
public class RoomLightTrigger : GameTrigger
{
    [SerializeField] private Room _room;
    [SerializeField] private bool _isLighted;

    public override void ActivateTrigger()
    {
        HouseState.Instance.GetRoomState(_room).isLighting = _isLighted;
    }
}
