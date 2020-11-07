using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Triggers/CharacterDefinitionTrigger")]
public class CharacterDefinitionTrigger : GameTrigger
{
    [SerializeField] private Character _character;
    [SerializeField] private int _definitionIndex;

    public override void ActivateTrigger()
    {
        HouseState.Instance.GetCharacterState(_character).CurrentCharacterDefinition =
            _character.CharacterDefinitions[_definitionIndex];
    }
}
