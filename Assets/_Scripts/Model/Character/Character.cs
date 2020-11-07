using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Characters/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _dialogSprite;
    [SerializeField] private List<CharacterDefinition> _characterDefinitions;

    public string Name => _name;
    public Sprite DialogSprite => _dialogSprite;
    public List<CharacterDefinition> CharacterDefinitions => _characterDefinitions;
}
