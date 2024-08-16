using System.Collections;
using TMPro;
using UnityEngine;

namespace CastleRush.UI
{
    public class UISCountdown : UIStagePanel
    {
        protected override UI_STAGE_STATE m_state
            => UI_STAGE_STATE.COUNTDOWN;

        [SerializeField] private int MaxCount = 3;
        [SerializeField] private float m_currentTimeCount = 3f;
        public float CurrentTimeCount
            => m_currentTimeCount;
        public float SetCurrentTimeCount(float value)
            => m_currentTimeCount = value;


        [SerializeField] private float m_cooldownTimeSpeed = 1f;
        public float CooldownTimeSpeed 
            => m_cooldownTimeSpeed;

        [SerializeField] private TMP_Text m_CounterText;
        private void SetCounterText(string text) 
            => m_CounterText.text = text;

        public override void Execute()
        {
            base.Execute();

            RestartCountDown();
        }

        private void RestartCountDown()
        {
            SetCurrentTimeCount(MaxCount);
            StartCoroutine(CountdownCoroutine());
        }

        IEnumerator CountdownCoroutine()
        {
            while (true)
            {
                SetCounterText(
                    Mathf.CeilToInt(
                        SetCurrentTimeCount(
                                CurrentTimeCount - (CooldownTimeSpeed * Time.deltaTime)
                                )
                        ).ToString()
                    );

                if(CurrentTimeCount <= 0)
                    FinishCountdown();

                yield return null;
            }
        }

        private void FinishCountdown()
        {
            StopAllCoroutines();

            SetCounterText("START");

            // End State
            StartCoroutine(EndAndStartMatchCoroutine());
        }

        IEnumerator EndAndStartMatchCoroutine()
        {
            yield return new WaitForSeconds(2f);

            End();
        }
    }
}
