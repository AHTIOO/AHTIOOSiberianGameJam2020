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

    private Sequence _sequence;

    [EditorButton]
    public void MessegePlayer(string messege, float time = 2f)
    {
        if (textBox.text == messege)
            return;

        _sequence?.Kill();
        _sequence = DOTween.Sequence();

        if (popUpBox.anchoredPosition != new Vector2(0, popUpRange))
        {
            _sequence.Append(popUpBox.DOAnchorPos(new Vector2(0, popUpRange), PopUpTime).SetEase(ease));
        }

        _sequence.AppendCallback(() => textBox.text = messege);
        _sequence.Append(popUpBox.DOAnchorPos(new Vector2(0, -popUpRange),PopUpTime).SetEase(ease));
        _sequence.AppendInterval(time);
        _sequence.Append(popUpBox.DOAnchorPos(new Vector2(0, popUpRange), PopUpTime).SetEase(ease));
    }
}
