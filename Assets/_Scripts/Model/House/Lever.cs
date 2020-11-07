using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/House/Lever", fileName = "Lever")]
public class Lever : ScriptableObject
{
    [SerializeField] private bool _isWorkByDefault;
    [SerializeField] private List<Room> _roomToSwitch = new List<Room>();

    public bool IsWorkByDefault => _isWorkByDefault;
    public List<Room> RoomToSwitch => _roomToSwitch;
}
