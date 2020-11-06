using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/House/Floor", fileName = "Floor")]
public class Floor : ScriptableObject
{
    [SerializeField] private List<Room> _rooms = new List<Room>();

    public List<Room> Rooms => _rooms;
}
