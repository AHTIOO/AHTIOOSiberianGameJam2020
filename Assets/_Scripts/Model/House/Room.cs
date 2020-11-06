using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/House/Room", fileName = "Room")]
public class Room : ScriptableObject
{
    [Header("Room data")]
    [SerializeField] private Sprite _sprite;

    [Header("Connected Rooms")]
    [SerializeField] private List<Room> _connectedRoom = new List<Room>();

    public Sprite Sprite => _sprite;
    public List<Room> ConnectedRoom => _connectedRoom;
}
