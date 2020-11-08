using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Singleton<Map>
{
    private Dictionary<Room, MapPart> _mapParts = new Dictionary<Room, MapPart>();

    protected override void Awake()
    {
        base.Awake();

        foreach (var mapPart in GetComponentsInChildren<MapPart>())
        {
            _mapParts.Add(mapPart.Room, mapPart);
        }
    }

    public void UpdateMap(Room newRoom)
    {
        _mapParts[newRoom].gameObject.SetActive(true);
        _mapParts[newRoom].SetPlayer(true);
        _mapParts[newRoom].UpdateCharacters();

        foreach (var partsKey in _mapParts.Keys)
        {
            if (partsKey != newRoom)
            {
                _mapParts[partsKey].SetPlayer(false);
            }
        }
    }
}
