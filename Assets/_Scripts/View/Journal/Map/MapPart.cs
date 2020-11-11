using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapPart : MonoBehaviour
{
    [SerializeField] private Room _room;

    [Header("Content")]
    [SerializeField] private GameObject _playerIcon;

    [SerializeField] private Image _image;
    [SerializeField] private Color _lightColor = Color.white;
    [SerializeField] private Color _darkColor = Color.gray;

    [SerializeField] private List<Image> _characterImages = new List<Image>();
    
    public Room Room => _room;

    public void SetPlayer(bool isPlayerInRoom)
    {
        _playerIcon.SetActive(isPlayerInRoom);
    }

    public void UpdateLight()
    {
        _image.color = HouseState.Instance.GetRoomState(_room).isLighting ? _lightColor : _darkColor;
    }

    public void UpdateCharacters()
    {
        var chars = HouseState.Instance.GetRoomState(_room).CharactersOnLocations;

        for (int i = 0; i < _characterImages.Count; i++)
        {
            if (i > chars.Count - 1)
            {
                _characterImages[i].gameObject.SetActive(false);
            }
            else
            {
                _characterImages[i].sprite = chars[i].MenuIcon;
                _characterImages[i].gameObject.SetActive(true);
            }
        }
    }
}
