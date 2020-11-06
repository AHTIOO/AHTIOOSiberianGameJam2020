using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomState 
{
    bool isLighting { get; set; }
    public RoomState(Room room)
    {
        isLighting = room.IsLightDefault;
    }

   
}
