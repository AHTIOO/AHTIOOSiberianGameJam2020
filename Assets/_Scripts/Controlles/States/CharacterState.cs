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

    public void SetToDark()
    {
        if (!IsAlive)
            return;

        GameTime timeToDie = new GameTime(GameTimeHolder.Instance.CurrentTime);
        timeToDie.Add(GameTimeHolder.Instance.TimeToDie);
        TimeTriggerController.Instance.AddTimeTrigger(new TimeTriggerController.TimeTrigger(timeToDie, new List<GameTrigger>() {new CharacterDeathTrigger(_model)}));
        DialogManager.Instance.Begin(_model.InDarkDialog, _model, _isAlive);
    }

    public void TryToDie()
    {
        if (!HouseState.Instance.GetRoomState(HouseState.Instance.GetCharacterCurrentRoom(_model)).isLighting)
        {
            IsAlive = false;
        }
    }

    public CharacterDefinition CurrentCharacterDefinition
    {
        get => _currentDefinition;
        set
        {
            if (!IsAlive)
            {
                _currentDefinition = value;
                return;
            }

            if (_currentDefinition != null)
                HouseState.Instance.GetRoomState(_currentDefinition.Position).CharactersOnLocations.Remove(_model);

            _currentDefinition = value;
            HouseState.Instance.GetRoomState(_currentDefinition.Position).CharactersOnLocations.Add(_model);
            RoomSwicher.Instance.ForceUpdate();
        }
    }

    public CharacterState(Character character)
    {
        IsAlive = true;
        _model = character;
        CurrentCharacterDefinition = character.CharacterDefinitions[0];
    }
}
