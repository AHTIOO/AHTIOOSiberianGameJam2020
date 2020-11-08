using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Triggers/CharacterDeath")]
public class CharacterDeathTrigger : GameTrigger
{
    [SerializeField] private Character _character;

    public override void ActivateTrigger()
    {
        HouseState.Instance.GetCharacterState(_character).TryToDie();
    }

    public CharacterDeathTrigger(Character character)
    {
        _character = character;
    }
}
