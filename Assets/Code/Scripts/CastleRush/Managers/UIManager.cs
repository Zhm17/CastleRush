using Utils;
using UnityEngine;

namespace CastleRush
{
    public class UIManager : Singleton<UIManager>
    {
        [Header("Canvas")]
        [SerializeField] public Canvas InteractiveCanvas;

        [Header("Victory Panel")]
        [SerializeField] private GameObject VictoryPanel;

        [Header("Game Over Panel")]
        [SerializeField] private GameObject GameOverPanel;

        protected override void Init()
        {

        }
    }
}
