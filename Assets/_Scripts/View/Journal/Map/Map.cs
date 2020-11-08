using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : Singleton<Map>
{
    [SerializeField] private List<MapPart> _mapParts = new List<MapPart>();
    
    public void UpdateMap(Room newRoom)
    {
        MapPart mapPart = _mapParts.Find(x => x.Room == newRoom);
        mapPart.gameObject.SetActive(true);
        mapPart.SetPlayer(true);

        foreach (var mp in _mapParts)
        {
            if (mp.Room != newRoom)
            {
                mp.SetPlayer(false);
            }
        }
    }

    private void Update()
    {
        foreach (var mapPart in _mapParts)
        {
            mapPart.UpdateLight();
            mapPart.UpdateCharacters();
        }
    }
}
