using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseState : Singleton<HouseState>
{
    [SerializeField]private HouseModel _houseModel;
    [SerializeField]private CharactersModel _charactersModel;

    private Dictionary<Room, RoomState> _rooms;
    private Dictionary<Character, CharacterState> _characters;

    public RoomState GetRoomState(Room room)
    {
        return _rooms[room];
    }

    public CharacterState GetCharacterState(Character character)
    {
        return _characters[character];
    }

    protected override void Awake()
    {
        base.Awake();

       InitializeRooms();
       InitializeCharacters();
    }

    private void InitializeRooms()
    {
        _rooms = new Dictionary<Room, RoomState>();
        foreach(Floor floor in _houseModel.floors)
        {
            foreach(Room room in floor.Rooms)
            {
                _rooms.Add(room, new RoomState(room));
            }
        }
    }

    private void InitializeCharacters()
    {
        _characters = new Dictionary<Character, CharacterState>();
        foreach (var character in _charactersModel.Characters)
        {
            _characters.Add(character, new CharacterState(character));
        }
    }
}
