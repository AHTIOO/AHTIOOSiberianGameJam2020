using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseModel : MonoBehaviour
{
    [SerializeField] private List<Floor> _floors = new List<Floor>();
    [SerializeField] private List<Lever> _levers = new List<Lever>();

    public List<Floor> floors => _floors;
    public List<Lever> Lever => _levers;
}
