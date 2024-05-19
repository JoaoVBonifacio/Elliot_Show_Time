using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerTest : MonoBehaviour
{
    public Button[] buttons;
    public Vector3[] Move;
    public RectTransform[] DorectTransform;

    private void Start()
    {
        // Verifica se há botões no array
        if (buttons != null && buttons.Length > 0)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = i; // Necessário para evitar problemas de fechamento de loop
                buttons[index].onClick.AddListener(() => OnButtonClicked(index));
            }
        }
    }

    private void OnDestroy()
    {
        // Remove os listeners ao destruir o objeto
        if (buttons != null && buttons.Length > 0)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = i;
                buttons[index].onClick.RemoveListener(() => OnButtonClicked(index));
            }
        }
    }

    private void OnButtonClicked(int index)
    {
        Debug.Log($"Botão {index} foi clicado!");
        // Adicione aqui a lógica específica para cada botão, se necessário

        // Exemplo de animação com DoTween
        //RectTransform rectTransform = buttons[index].GetComponent<RectTransform>();

        if (index == 0)
        {
            // Fazer uma animação de scale para 1.2 e depois voltar para 1
            DorectTransform[0].DOMove(new Vector3(Move[0].x, Move[0].y, Move[0].z), 1).OnComplete(() =>
            {
                Debug.Log($"Animação do botão {index} completa!");
                // Adicione aqui a lógica que você quer executar após a animação
                DoSomethingAfterAnimation(index);
            });
        }      

    }

    private void DoSomethingAfterAnimation(int index)
    {
        // Lógica específica após a animação do botão
        Debug.Log($"Executando ação pós-animação para o botão {index}");
        // Adicione aqui a lógica específica que você deseja
    }
}
