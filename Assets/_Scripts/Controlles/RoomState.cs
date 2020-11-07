using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomState 
{
    public bool isLighting { get; set; }
    public readonly List<Character> CharactersOnLocations;

    public RoomState(Room room)
    {
        isLighting = room.IsLightDefault;
        CharactersOnLocations = new List<Character>();
    }

   
}
