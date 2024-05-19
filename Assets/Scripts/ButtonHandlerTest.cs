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
        // Verifica se h� bot�es no array
        if (buttons != null && buttons.Length > 0)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = i; // Necess�rio para evitar problemas de fechamento de loop
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
        Debug.Log($"Bot�o {index} foi clicado!");
        // Adicione aqui a l�gica espec�fica para cada bot�o, se necess�rio

        // Exemplo de anima��o com DoTween
        //RectTransform rectTransform = buttons[index].GetComponent<RectTransform>();

        if (index == 0)
        {
            // Fazer uma anima��o de scale para 1.2 e depois voltar para 1
            DorectTransform[0].DOMove(new Vector3(Move[0].x, Move[0].y, Move[0].z), 1).OnComplete(() =>
            {
                Debug.Log($"Anima��o do bot�o {index} completa!");
                // Adicione aqui a l�gica que voc� quer executar ap�s a anima��o
                DoSomethingAfterAnimation(index);
            });
        }      

    }

    private void DoSomethingAfterAnimation(int index)
    {
        // L�gica espec�fica ap�s a anima��o do bot�o
        Debug.Log($"Executando a��o p�s-anima��o para o bot�o {index}");
        // Adicione aqui a l�gica espec�fica que voc� deseja
    }
}
