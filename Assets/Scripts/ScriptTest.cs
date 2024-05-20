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
        // Verifica se há botões no array
        if (buttons != null && buttons.Length > 0)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                int index = i; // Necessário para evitar problemas de fechamento de loop
                buttons[index].onClick.AddListener(() => OnButtonClicked(index));
            }
        }

        // Adiciona um listener ao botão de confirmação
        confirmbutton.onClick.AddListener(OnConfirmButtonClicked);
    }

    public void OnButtonClicked(int index)
    {
        Debug.Log($"Botão {index} foi clicado!");
        selectedButtonIndex = index;
        HandleButtonClick(index);
    }

    // Método chamado quando o botão de confirmação é clicado
    public void OnConfirmButtonClicked()
    {
        if (selectedButtonIndex >= 0 && selectedButtonIndex < buttons.Length)
        {
            Debug.Log($"Confirmação do botão {selectedButtonIndex}!");

            if(selectedButtonIndex == 0)
            {
                Panel.GetComponent<DOTweenAnimation>().DOPlay();
            }
        }
        else
        {
            Debug.Log("Nenhum botão foi selecionado para confirmação.");
        }
    }

    // Método auxiliar para lidar com o clique do botão
    public void HandleButtonClick(int buttonIndex)
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

    public void OnPointerClick()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        if (rectTransform != null)
        {
            rectTransform.sizeDelta = new Vector2(newWidth, newHeight);
        }
    }
}
