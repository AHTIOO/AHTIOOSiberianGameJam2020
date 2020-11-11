using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FadeTransfer : MonoBehaviour
{
    public Image image;
    public float TransitionSpeed = 0.2f;
    void Start()
    {
        image.DOFade(0, TransitionSpeed);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
