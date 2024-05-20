using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeRectSizeOnClick : MonoBehaviour, IPointerClickHandler
{
    public float newWidth = 200f; // Novo valor para a largura
    public float newHeight = 200f; // Novo valor para a altura

    // Este m�todo � chamado quando o objeto � clicado
    public void OnPointerClick(PointerEventData eventData)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        if (rectTransform != null)
        {
            rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
        }
    }
}
