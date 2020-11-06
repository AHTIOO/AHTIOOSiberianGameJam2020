using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StepsRoomTransition : RoomTransitionEffect
{
    [SerializeField] private float _transitionTime;
    [SerializeField] private AudioSource _stepsSource;

    public override Tween DoTransition()
    {
        return DOTween.Sequence().AppendInterval(_transitionTime);
    }
}
