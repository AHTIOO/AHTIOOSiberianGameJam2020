using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class RoomSwicher : MonoBehaviour
{
    public CanvasGroup transitionScreen;
    public float transitionSpeed = 0.012f;
    public GameObject RoomParent;

    private Room curentRoom;

    public void GoToRoom(Room goesToRoom)
    {
        transitionScreen.DOFade(1, transitionSpeed);
        Destroy(curentRoom);
        curentRoom = goesToRoom;
        Instantiate(curentRoom, RoomParent.transform);
        transitionScreen.DOFade(0, transitionSpeed);
    }
}

