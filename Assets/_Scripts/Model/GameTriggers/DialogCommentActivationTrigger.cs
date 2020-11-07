using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

[CreateAssetMenu(menuName = "DATA/Triggers/DialogTrigger")]
public class DialogCommentActivationTrigger : GameTrigger
{
    [SerializeField] private string _dialog;
    [SerializeField] private int _node;
    [SerializeField] private int _comment;
    [SerializeField] private bool _isVisible;

    public override void ActivateTrigger()
    {
        VD.SetVisible(_dialog, _node, _comment, _isVisible);
    }
}
