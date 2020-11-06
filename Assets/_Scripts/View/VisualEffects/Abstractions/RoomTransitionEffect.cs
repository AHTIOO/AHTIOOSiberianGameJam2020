using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class RoomTransitionEffect : MonoBehaviour
{
    public abstract Tween DoTransition();
}
