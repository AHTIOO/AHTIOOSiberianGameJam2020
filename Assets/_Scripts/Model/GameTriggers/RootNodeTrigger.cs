using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VIDE_Data;

[CreateAssetMenu(menuName = "DATA/Triggers/RootNodeTrigger")]
public class RootNodeTrigger : GameTrigger
{
    [SerializeField] private string _dialog;
    [SerializeField] private int _newNode;

    public override void ActivateTrigger()
    {

        VD.assigned.overrideStartNode = _newNode;


    }
}
