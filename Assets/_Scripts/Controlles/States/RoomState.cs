using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomState 
{
    public bool isLighting { get; set; }
    public readonly List<Character> CharactersOnLocations;

    public readonly List<Room.RoomConnection> RoomConnections;


    public RoomState(Room room)
    {
        isLighting = room.IsLightDefault;
        CharactersOnLocations = new List<Character>();
        RoomConnections = new List<Room.RoomConnection>();

        foreach (var roomConnection in room.ConnectedRoom)
        {
            RoomConnections.Add(new Room.RoomConnection(roomConnection));
        }
    }
}
