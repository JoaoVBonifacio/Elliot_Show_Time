using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptTest : MonoBehaviour
{

    public RectTransform[] buttons; // Assuma que estamos animando os RectTransforms dos botões
    private int animationsCompleted = 0;
    public Button[] test;

    void Start()
    {
        //StartButtonAnimations();

        /*if (test[1].)
        {

        }*/
    }

    /*public void StartButtonAnimations()
    {
        animationsCompleted = 0;

        foreach (RectTransform button in buttons)
        {
            // Exemplo de animação: movendo o botão
            button.DOAnchorPos(new Vector2(0, 0), 1f)
                .OnComplete(OnButtonAnimationEnd);
        }
    }*/

   public void OnButtonAnimationEnd()
    {
        animationsCompleted++;
        if (animationsCompleted == buttons.Length)
        {
            Debug.Log("Todas as animações dos botões foram concluídas!");
            // Aqui você pode chamar outras funções ou métodos que dependem do término das animações
        }

    }

    // Método chamado quando um botão é clicado
    public void OnButtonClick(RectTransform clickedButton)
    {
        // Verifica qual botão foi clicado
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] == clickedButton)
            {
                //Debug.Log("Botão " + i + " foi clicado!");
                // Execute a ação desejada com o botão clicado
                HandleButtonClick(i);
                break;
            }
        }
    }

    // Método auxiliar para lidar com o clique do botão
    private void HandleButtonClick(int buttonIndex)
    {
        // Implemente aqui o que deve acontecer quando o botão for clicado
        switch (buttonIndex)
        {
            case 0:
                Debug.Log("Botão " + buttonIndex + " foi clicado!");
                break;
            case 1:
                Debug.Log("Botão " + buttonIndex + " foi clicado!");
                break;
            // Adicione outros cases conforme necessário
            default:
                Debug.Log("Ação para o botão " + buttonIndex);
                break;
        }
    }
}
