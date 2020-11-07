using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersModel : MonoBehaviour
{
    [SerializeField] private List<Character> _characters = new List<Character>();

    public List<Character> Characters => _characters;
}
