using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/House/Lever", fileName = "Lever")]
public class Lever : ScriptableObject
{
    [SerializeField] private bool _isWorkByDefault;

    public bool IsWorkByDefault => _isWorkByDefault;
}
