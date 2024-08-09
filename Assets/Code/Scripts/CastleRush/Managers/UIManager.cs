using Utils;
using UnityEngine;
using Generics;

namespace CastleRush.UI
{
    public class UIManager : Singleton<UIManager>
    {
        // State
        [SerializeField] private UI_STAGE_STATE m_currState;
        public UI_STAGE_STATE CurrentState
            => m_currState;
        private void SetCurrentState(UI_STAGE_STATE state)
            => m_currState = state;
        

        // Canvas
        [Header("Stage Canvas")]
        [SerializeField] private Canvas m_stageCanvas;
        public Canvas StageCanvas
            => m_stageCanvas;

        // Panels
        [Header("Level Title Panel")]
        [SerializeField] private UISLevelTitle LevelTitlePanel;
        [Header("Countdown Panel")]
        [SerializeField] private UISCountdown CountdownPanel;
        [Header("In Game Panel")]
        [SerializeField] private UISInGame InGamePanel;
        [Header("You Won Panel")]
        [SerializeField] private UISYouWon YouWonPanel;
        [Header("Game Over Panel")]
        [SerializeField] private UISGameOver GameOverPanel;


        protected override void Init()
        {
            // Set state after ending the previous one
            UIStagePanel.OnEndUISState += SetUIStageState;
            // On Win
            ScoreComponent.OnHighScoreReached += MatchWon;
            // On Game Over
            CrystalPlatformBase.OnMatchLost += MatchLost;

            SetTitle();
        }

        private void OnDisable()
        {
            UIStagePanel.OnEndUISState -= SetUIStageState;
            ScoreComponent.OnHighScoreReached -= MatchWon;
            CrystalPlatformBase.OnMatchLost -= MatchLost;
        }

        protected override void OnDestroy()
        {
           
            UIStagePanel.OnEndUISState -= SetUIStageState;
            ScoreComponent.OnHighScoreReached -= MatchWon;
            CrystalPlatformBase.OnMatchLost -= MatchLost;

            base.OnDestroy();
        }


#region EVENTS AFTERWARD

        private void SetUIStageState(UI_STAGE_STATE state)
        {
            if ((int) state > 2)
                return;

            switch (state)
            {
                case UI_STAGE_STATE.DEFAULT:
                    SetTitle();
                    break;
                case UI_STAGE_STATE.LEVEL_TITLE:
                    SetCountdown();
                    break;
                case UI_STAGE_STATE.COUNTDOWN:
                    SetInGame();
                    break;
            }
        }

        private void MatchWon()
        {
            if (CurrentState != UI_STAGE_STATE.INGAME)
                return;

            SetYouWon();
        }

        private void MatchLost()
        {
            if (CurrentState != UI_STAGE_STATE.INGAME)
                return;

            SetGameOver();
        }
#endregion



#region ENABLE STATES AND ACTIVE PANELS
        private void SetDefault()
        {
            SetCurrentState(UI_STAGE_STATE.DEFAULT);
        }

        private void SetTitle()
        {
            SetCurrentState(UI_STAGE_STATE.LEVEL_TITLE);
            LevelTitlePanel.Execute();
        }

        private void SetCountdown()
        {
            SetCurrentState(UI_STAGE_STATE.COUNTDOWN);
            CountdownPanel.Execute();
        }

        private void SetInGame()
        {
            SetCurrentState(UI_STAGE_STATE.INGAME);
            InGamePanel.Execute();
        }

        private void SetYouWon()
        {
            SetCurrentState(UI_STAGE_STATE.YOU_WON);
            YouWonPanel.Execute();
        }

        private void SetGameOver()
        {
            SetCurrentState(UI_STAGE_STATE.GAMEOVER);
            GameOverPanel.Execute();
        }
#endregion

    }

}
