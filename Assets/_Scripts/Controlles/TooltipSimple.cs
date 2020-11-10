using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSimple : TooltipBase
{
    public string Message;

    protected override void UpdateTooltipMessage()
    {
        tooltipView.SetTooltipText(Message);
    }
}
