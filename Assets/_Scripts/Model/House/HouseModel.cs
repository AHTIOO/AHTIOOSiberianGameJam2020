using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/House/House", fileName = "House")]
public class HouseModel : ScriptableObject
{
    [SerializeField] private List<Floor> _floors = new List<Floor>();
}
