using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class ScaleAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public float defaultSize;
    public float scaledSize;
    public float transitionSpeed;

    RectTransform _rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _rectTransform.DOScale(new Vector3(scaledSize, scaledSize, scaledSize), transitionSpeed);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _rectTransform.DOScale(new Vector3(defaultSize, defaultSize, defaultSize), transitionSpeed);
    }
}
