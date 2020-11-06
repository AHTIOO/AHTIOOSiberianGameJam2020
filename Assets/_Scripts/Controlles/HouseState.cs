using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseState : Singleton<HouseState>
{
    private Dictionary<Room, RoomState> _houseState;
    public RoomState getRoomState(Room room)
    {
        return _houseState[room];
    }
}
