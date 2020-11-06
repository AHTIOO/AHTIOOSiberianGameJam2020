using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/House/Room", fileName = "Room")]
public class Room : ScriptableObject
{
    [Header("Room data")]
    [SerializeField] private RoomView _roomPrefab;
    [SerializeField] private bool isLightDefault;

    [Header("Connected Rooms")]
    [SerializeField] private List<Room> _connectedRoom = new List<Room>();
    
    public RoomView RoomPrefab => _roomPrefab;
    public List<Room> ConnectedRoom => _connectedRoom;
    public bool IsLightDefault => isLightDefault;
}
