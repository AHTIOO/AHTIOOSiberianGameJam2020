using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Ambient : MonoBehaviour
{
    [SerializeField] private AudioSource _initial;
    [SerializeField] private AudioSource _main;

    private Sequence _sequence;

    private void Awake()
    {
        _initial.loop = true;
        _initial.Play();

        _initial.volume = 1f;
        _main.volume = 0f;
    }

    public void Change()
    {
        _sequence?.Kill();

        _main.loop = true;
        _main.Play();
        _sequence.Join(_initial.DOFade(0, 2f));
        _sequence.Join(_main.DOFade(1, 2f));
    }
}
