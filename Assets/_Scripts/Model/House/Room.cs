using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/House/Room", fileName = "Room")]
public class Room : ScriptableObject
{
    [Serializable]
    public class RoomConnection
    {
        public Room connectedRoom;
        public bool isAvailableByDefault;
    }

    [Header("Room data")]
    [SerializeField] private RoomView _roomPrefab;
    [SerializeField] private bool isLightDefault;

    [Header("Connected Rooms")]
    [SerializeField] private List<RoomConnection> _connectedRoom = new List<RoomConnection>();
    
    public RoomView RoomPrefab => _roomPrefab;
    public List<RoomConnection> ConnectedRoom => _connectedRoom;
    public bool IsLightDefault => isLightDefault;
}
