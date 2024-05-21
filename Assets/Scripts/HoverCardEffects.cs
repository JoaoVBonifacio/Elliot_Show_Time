using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverCardEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RectTransform rectTransform;
    private Vector2 originalSizeDelta;
    public Vector2 hoverSizeDelta = new Vector2(120f, 120f);
    private Vector2 targetSizeDelta;
    public float smoothTime = 0.2f;
    private Vector2 velocity = Vector2.zero;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalSizeDelta = rectTransform.sizeDelta;
        targetSizeDelta = originalSizeDelta;
    }

    void Update()
    {
        rectTransform.sizeDelta = Vector2.SmoothDamp(rectTransform.sizeDelta, targetSizeDelta, ref velocity, smoothTime);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        targetSizeDelta = hoverSizeDelta;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetSizeDelta = originalSizeDelta;
    }
}
