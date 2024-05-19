using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandlerTest : MonoBehaviour
{
    public Button[] buttons;
    public Vector3[] Move;
    public RectTransform[] DorectTransform;
    public float speedanimation;
    public GameObject[] Menus;

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
        //Debug.Log($"Botão {index} foi clicado!");
        // Adicione aqui a lógica específica para cada botão, se necessário

        // Exemplo de animação com DoTween
        //RectTransform rectTransform = buttons[index].GetComponent<RectTransform>();

        if (index == 0 || index == 1 || index == 2 || index == 3 || index == 4)
        {
            // Fazer uma animação de scale para 1.2 e depois voltar para 1
            DorectTransform[0].DOMove(new Vector3(Move[0].x, Move[0].y, Move[0].z), speedanimation).OnComplete(() =>
            {
                DorectTransform[1].DOMove(new Vector3(Move[1].x, Move[1].y, Move[1].z), speedanimation).OnComplete(() =>
                {
                    DorectTransform[2].DOMove(new Vector3(Move[2].x, Move[2].y, Move[2].z), speedanimation).OnComplete(() =>
                    {
                        DorectTransform[3].DOMove(new Vector3(Move[3].x, Move[3].y, Move[3].z), speedanimation).OnComplete(() =>
                        {
                            DorectTransform[4].DOMove(new Vector3(Move[4].x, Move[4].y, Move[4].z), speedanimation).OnComplete(() =>
                            {
                                DoSomethingAfterAnimation(index);
                            });
                        });
                    });
                });
            });
        }
    }

    private void DoSomethingAfterAnimation(int index)
    {
        // Lógica específica após a animação do botão
        Debug.Log($"Executando ação pós-animação para o botão {index}");
        // Adicione aqui a lógica específica que você deseja
        switch(index)
        {
            case 1:
                Debug.Log("Botão " + index + " foi clicado!");
                SceneManager.LoadScene(1);
                break;
            case 2:
                Debug.Log("Botão " + index + " foi clicado!");
                break;
            case 3:
                Debug.Log("Botão " + index + " foi clicado!");
                break;
            case 4:
                Debug.Log("Botão " + index + " foi clicado!");
                Application.Quit();
                break;
        }
    }

    public void ResetOffset()
    {
        //Top
        DorectTransform[0].offsetMax = new Vector2(1, 0.811f);
        DorectTransform[0].offsetMin = new Vector2(0.9030001f, 0.526f);
        //1
        DorectTransform[1].offsetMax = new Vector2(1, 0.6785555f);
        DorectTransform[1].offsetMin = new Vector2(0.5404792f, 0.377f);

        //2
        DorectTransform[2].offsetMax = new Vector2(1, 0.484f);
        DorectTransform[2].offsetMin = new Vector2(0.631f, 0.229f);
        //3
        DorectTransform[3].offsetMax = new Vector2(1, 0.287f);
        DorectTransform[3].offsetMin = new Vector2(0.725f, 0.07300001f);
        //Bottom
        DorectTransform[4].offsetMax = new Vector2(1, 0.1176667f);
        DorectTransform[4].offsetMin = new Vector2(0.7360001f, 0f);
    }
}
