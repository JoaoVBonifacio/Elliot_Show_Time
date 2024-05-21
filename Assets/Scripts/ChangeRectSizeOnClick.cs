using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class ChangeRectSizeOnClick : MonoBehaviour
{
    public float newWidth = 200f; // Novo valor para a largura
    public float newHeight = 200f; // Novo valor para a altura
    public float transitionDuration = 0.5f; // Duração da transição

    public RectTransform[] rectTransforms; // Array de RectTransforms para gerenciar
    private Vector2[] originalSizes; // Array para armazenar os tamanhos originais

    private RectTransform lastClickedRectTransform = null;

    void Start()
    {
        // Inicializa o array de tamanhos originais
        originalSizes = new Vector2[rectTransforms.Length];

        // Armazena os tamanhos originais de cada RectTransform
        for (int i = 0; i < rectTransforms.Length; i++)
        {
            if (rectTransforms[i] != null)
            {
                originalSizes[i] = rectTransforms[i].sizeDelta;
            }
        }

        // Adiciona listeners de clique a todos os RectTransforms
        foreach (RectTransform rt in rectTransforms)
        {
            EventTrigger trigger = rt.gameObject.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = rt.gameObject.AddComponent<EventTrigger>();
            }

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((eventData) => { OnPointerClick(rt); });
            trigger.triggers.Add(entry);
        }
    }

    public void OnPointerClick(RectTransform clickedRectTransform)
    {
        // Redimensiona o último clicado para o tamanho original
        if (lastClickedRectTransform != null && lastClickedRectTransform != clickedRectTransform)
        {
            int lastIndex = System.Array.IndexOf(rectTransforms, lastClickedRectTransform);
            if (lastIndex >= 0)
            {
                StopAllCoroutines();
                StartCoroutine(ResizeSmoothly(lastClickedRectTransform, originalSizes[lastIndex], transitionDuration));
            }
        }

        // Atualiza a referência do último clicado
        lastClickedRectTransform = clickedRectTransform;

        // Redimensiona o atual suavemente
        StartCoroutine(ResizeSmoothly(clickedRectTransform, new Vector2(newWidth, newHeight), transitionDuration));
    }

    private IEnumerator ResizeSmoothly(RectTransform targetRectTransform, Vector2 targetSize, float duration)
    {
        Vector2 currentSize = targetRectTransform.sizeDelta;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            targetRectTransform.sizeDelta = Vector2.Lerp(currentSize, targetSize, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        targetRectTransform.sizeDelta = targetSize;
    }
}
