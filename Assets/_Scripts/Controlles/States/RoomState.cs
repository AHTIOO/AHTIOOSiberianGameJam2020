using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomState
{
    private bool _isLighted;

    public bool isLighting
    {
        get => _isLighted;
        set
        {
            _isLighted = value;
            if (!isLighting)
            {
                foreach (var character in CharactersOnLocations)
                {
                    HouseState.Instance.GetCharacterState(character).SetToDark();
                }
            }
        }
    }
    public readonly List<Character> CharactersOnLocations;

    public readonly List<Room.RoomConnection> RoomConnections;


    public RoomState(Room room)
    {
        _isLighted = room.IsLightDefault;
        CharactersOnLocations = new List<Character>();
        RoomConnections = new List<Room.RoomConnection>();

        foreach (var roomConnection in room.ConnectedRoom)
        {
            RoomConnections.Add(new Room.RoomConnection(roomConnection));
        }
    }
}
