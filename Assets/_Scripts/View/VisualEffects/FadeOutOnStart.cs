using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadeOutOnStart : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeTime;

    void Awake()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.DOFade(0, _fadeTime);
    }
}
