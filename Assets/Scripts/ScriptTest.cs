using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptTest : MonoBehaviour
{

    public RectTransform[] buttons; // Assuma que estamos animando os RectTransforms dos bot�es
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
            // Exemplo de anima��o: movendo o bot�o
            button.DOAnchorPos(new Vector2(0, 0), 1f)
                .OnComplete(OnButtonAnimationEnd);
        }
    }*/

   public void OnButtonAnimationEnd()
    {
        animationsCompleted++;
        if (animationsCompleted == buttons.Length)
        {
            Debug.Log("Todas as anima��es dos bot�es foram conclu�das!");
            // Aqui voc� pode chamar outras fun��es ou m�todos que dependem do t�rmino das anima��es
        }

    }

    // M�todo chamado quando um bot�o � clicado
    public void OnButtonClick(RectTransform clickedButton)
    {
        // Verifica qual bot�o foi clicado
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] == clickedButton)
            {
                //Debug.Log("Bot�o " + i + " foi clicado!");
                // Execute a a��o desejada com o bot�o clicado
                HandleButtonClick(i);
                break;
            }
        }
    }

    // M�todo auxiliar para lidar com o clique do bot�o
    private void HandleButtonClick(int buttonIndex)
    {
        // Implemente aqui o que deve acontecer quando o bot�o for clicado
        switch (buttonIndex)
        {
            case 0:
                Debug.Log("Bot�o " + buttonIndex + " foi clicado!");
                break;
            case 1:
                Debug.Log("Bot�o " + buttonIndex + " foi clicado!");
                break;
            // Adicione outros cases conforme necess�rio
            default:
                Debug.Log("A��o para o bot�o " + buttonIndex);
                break;
        }
    }
}
