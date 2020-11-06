using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseModel : MonoBehaviour
{
    [SerializeField] private List<Floor> _floors = new List<Floor>();
    public List<Floor> floors => _floors;
}
