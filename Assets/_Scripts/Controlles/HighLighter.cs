using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class HighLighter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    [SerializeField] private float _sizeChanegeOn = 2f;
    [SerializeField] private float _animSpeed = 0.25f;
    [SerializeField] private Ease ease;

    public void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        rectTransform.DOScale(new Vector2(_sizeChanegeOn, _sizeChanegeOn), _animSpeed).SetEase(ease);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.DOScale(new Vector2(1, 1), _animSpeed).SetEase(ease);
    }
}
