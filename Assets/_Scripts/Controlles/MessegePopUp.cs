using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MessegePopUp : Singleton<MessegePopUp>
{
    public RectTransform popUpBox;
    public float PopUpTime = 1;
    public float ShowUpTime = 1;
    public float popUpRange = 110f;

    [SerializeField] private Text textBox;
    [SerializeField] private Ease ease;


    [EditorButton]
    public void MessegePlayer(string messege)
    {
        textBox.text = messege;
        popUpBox.DOAnchorPos(new Vector2(0, -popUpRange),PopUpTime).SetEase(ease);
        popUpBox.DOAnchorPos(new Vector2(0, popUpRange), PopUpTime).SetEase(ease).SetDelay(ShowUpTime);
    }
}
