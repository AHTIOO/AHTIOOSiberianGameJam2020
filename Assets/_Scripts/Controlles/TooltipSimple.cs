using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSimple : TooltipBase
{
    public string Message;
    TooltipView tooltipView = new TooltipView();

    protected override void UpdateTooltipMessage()
    {
        tooltipView.SetTooltipText(Message);
    }
}
