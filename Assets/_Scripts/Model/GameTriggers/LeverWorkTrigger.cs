using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DATA/Triggers/LeverWorkTrigger")]
public class LeverWorkTrigger : GameTrigger
{
    [SerializeField] private Lever _lever;
    [SerializeField] private bool _isWork;

    public override void ActivateTrigger()
    {
        HouseState.Instance.GetLeverState(_lever).IsWork = _isWork;
    }
}
