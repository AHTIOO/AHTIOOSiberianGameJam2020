using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TooltipBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    protected TooltipView tooltipView;

    protected void Start()
    {
        tooltipView.SetTooltipInactive();
        UpdateTooltipMessage();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipView.SetTooltipActive();
        UpdateTooltipMessage();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipView.SetTooltipInactive();
    }

    protected abstract void UpdateTooltipMessage();
}
