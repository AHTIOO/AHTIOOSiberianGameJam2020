using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TooltipView : MonoBehaviour
{
    [SerializeField]private CanvasGroup _tooltipBody;
    [SerializeField]private Text _tooltipText;

    public float fadeTime;

    public void SetTooltipText(string message)
    {
        _tooltipText.text = message;
    }

    public void SetTooltipActive()
    {
        _tooltipBody.DOFade(0, fadeTime);
    }
    public void SetTooltipInactive()
    {
        _tooltipBody.DOFade(1, fadeTime);
    }
}
