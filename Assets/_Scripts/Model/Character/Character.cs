using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Characters/Character")]
public class Character : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _dialogSprite;
    [SerializeField] private Sprite _menuIcon;
    [SerializeField] private string _deathDialog;
    [SerializeField] private string _endgameDialog;
    [SerializeField] private string _inDarkDialog;
    [SerializeField] private List<CharacterDefinition> _characterDefinitions;

    [SerializeField] private AudioClip _standartClip;
    [SerializeField] private AudioClip _darkClip;

    public AudioClip StandartClip => _standartClip;
    public AudioClip DarkClip => _darkClip;

    public string Name => _name;
    public Sprite DialogSprite => _dialogSprite;
    public List<CharacterDefinition> CharacterDefinitions => _characterDefinitions;
    public string DeathDialog => _deathDialog;
    public string InDarkDialog => _inDarkDialog;

    public Sprite MenuIcon => _menuIcon;

    public string EndGameDialog => _endgameDialog;
}
