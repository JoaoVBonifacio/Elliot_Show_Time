
namespace Dypsloom.RhythmTimeline.UI
{
    using Dypsloom.RhythmTimeline.Scoring;
    using UnityEngine;
    using UnityEngine.UI;

    public class HyperChanger : MonoBehaviour
    {
        [Tooltip("The slider.")]
        [SerializeField] protected Slider m_Slider;
        [Tooltip("The image slider fill (optional).")]
        [SerializeField] protected Image m_SliderFill;
        [Tooltip("The Slider Gradient.")]
        [SerializeField] protected Gradient m_SliderGradient;

        public Image imageBar, Background;

        public Sprite newImageBar, newBackground; // A nova imagem que você deseja usar

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

                imageBar.sprite = newImageBar;
                Background.sprite = newBackground;
            }

        }
    }
}
