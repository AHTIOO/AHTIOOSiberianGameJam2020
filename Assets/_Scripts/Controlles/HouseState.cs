using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseState : Singleton<HouseState>
{
    [SerializeField]private HouseModel _houseModel;

    private Dictionary<Room, RoomState> _houseState;

    public RoomState getRoomState(Room room)
    {
        return _houseState[room];
    }

    protected override void Awake()
    {
        base.Awake();

        _houseState = new Dictionary<Room, RoomState>();
        foreach(Floor floor in _houseModel.floors)
        {
            foreach(Room room in floor.Rooms)
            {
                _houseState.Add(room, new RoomState(room));
            }
        }
    }
}
