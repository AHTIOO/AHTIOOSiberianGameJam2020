using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Characters/CharactersDefinition")]
public class CharacterDefinition : ScriptableObject
{
    [SerializeField] private string _dialog;
    [SerializeField] private Room _position;

    public string Dialog => _dialog;
    public Room Position => _position;
}
