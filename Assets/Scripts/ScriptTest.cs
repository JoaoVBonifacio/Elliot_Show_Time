using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class ScriptTest : MonoBehaviour
{
    public Button[] buttons;
    public Button confirmbutton;
    public int selectedButtonIndex = -1;
    public GameObject Panel;

    public float newWidth = 200f; // Novo valor para a largura
    public float newHeight = 200f; // Novo valor para a altura

    void Start()
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

        // Adiciona um listener ao bot�o de confirma��o
        confirmbutton.onClick.AddListener(OnConfirmButtonClicked);
    }

    public void OnButtonClicked(int index)
    {
        Debug.Log($"Bot�o {index} foi clicado!");
        selectedButtonIndex = index;
        HandleButtonClick(index);
    }

    // M�todo chamado quando o bot�o de confirma��o � clicado
    public void OnConfirmButtonClicked()
    {
        if (selectedButtonIndex >= 0 && selectedButtonIndex < buttons.Length)
        {
            Debug.Log($"Confirma��o do bot�o {selectedButtonIndex}!");

            if(selectedButtonIndex == 0)
            {
                Panel.GetComponent<DOTweenAnimation>().DOPlay();
            }
        }
        else
        {
            Debug.Log("Nenhum bot�o foi selecionado para confirma��o.");
        }
    }

    // M�todo auxiliar para lidar com o clique do bot�o
    public void HandleButtonClick(int buttonIndex)
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

    public void OnPointerClick()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        if (rectTransform != null)
        {
            rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
        }
    }
}
