
namespace Dypsloom.RhythmTimeline.UI
{
    using Dypsloom.RhythmTimeline.Scoring;
    using UnityEngine;
    using UnityEngine.UI;

    public class HyperChanger : MonoBehaviour
    {
        [Tooltip("The slider.")]
        [SerializeField] protected Slider m_Slider;
        [SerializeField] protected Slider m_Slider2;
        [Tooltip("The image slider fill (optional).")]
        [SerializeField] protected Image m_SliderFill;
        [SerializeField] protected Image m_SliderFill2;
        [Tooltip("The Slider Gradient.")]
        [SerializeField] protected Gradient m_SliderGradient;
        [SerializeField] protected Gradient m_SliderGradient2;

        //public RectTransform newFillRect;

        public GameObject hyperPanel;


        public void SetRank(float p, ScoreRank rank)
        {
            if (m_Slider != null)
            {
                m_Slider.value = p;
            }

            if (m_SliderFill != null && m_SliderGradient != null)
            {
                m_SliderFill.color = m_SliderGradient.Evaluate(p / 100f);
            }

            // Verifica se o valor atual do slider é igual ao valor máximo
            if (m_Slider.value == m_Slider.maxValue)
            {
                Debug.Log("Slider atingiu 100%!");
                // Faça o que for necessário quando o slider atingir 100%

                m_Slider2.gameObject.SetActive(true);

                if (m_Slider2 != null && m_Slider2.IsActive())
                {
                    m_Slider2.value = p;
                }

                if (m_SliderFill2 != null && m_SliderGradient2 != null)
                {
                    m_SliderFill2.color = m_SliderGradient2.Evaluate(p / 100f);
                }

                if (m_Slider2.value == m_Slider2.maxValue)
                {
                    hyperPanel.SetActive(true);
                } else
                {
                    hyperPanel.SetActive(false);
                }

                

            }

            if(m_Slider.value == m_Slider.minValue)
            {
                m_Slider2.gameObject.SetActive(false);
            }

        }
    }
}
