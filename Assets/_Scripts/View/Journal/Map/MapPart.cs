using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPart : MonoBehaviour
{
    [SerializeField] private Room _room;

    [Header("Content")]
    [SerializeField] private GameObject _playerIcon;

    public Room Room => _room;

    public void SetPlayer(bool isPlayerInRoom)
    {
        _playerIcon.SetActive(isPlayerInRoom);
    }

    public void UpdateCharacters()
    {

    }
}
