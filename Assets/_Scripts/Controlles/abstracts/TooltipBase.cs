using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class TooltipBase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected TooltipView tooltipView = new TooltipView();

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
