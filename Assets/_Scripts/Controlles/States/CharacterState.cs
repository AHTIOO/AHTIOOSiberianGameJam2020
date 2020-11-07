using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState
{
    private Character _model;

    private bool _isAlive;
    private CharacterDefinition _currentDefinition;

    public bool IsAlive
    {
        get => _isAlive;
        set => _isAlive = value;
    }

    public CharacterDefinition CurrentCharacterDefinition
    {
        get => _currentDefinition;
        set
        {
            if (_currentDefinition != null)
                HouseState.Instance.GetRoomState(_currentDefinition.Position).CharactersOnLocations.Remove(_model);

            _currentDefinition = value;
            HouseState.Instance.GetRoomState(_currentDefinition.Position).CharactersOnLocations.Add(_model);
        }
    }

    public CharacterState(Character character)
    {
        IsAlive = true;
        _model = character;
        CurrentCharacterDefinition = character.CharacterDefinitions[0];
    }
}
