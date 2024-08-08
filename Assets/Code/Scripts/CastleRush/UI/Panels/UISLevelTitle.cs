using UnityEngine;
using TMPro;
using System.Collections;

namespace CastleRush.UI
{
    public class UISLevelTitle : UIStagePanel
    {
        protected override UI_STAGE_STATE m_state
            => UI_STAGE_STATE.LEVEL_TITLE;

        [SerializeField] private TMP_Text TitleText;

        public override void Execute()
        {
            base.Execute();

            StartCoroutine(ShowTitleCoroutine());
        }

        IEnumerator ShowTitleCoroutine()
        {
            yield return new WaitForSeconds(1f);

            if (TitleText)
                TitleText.SetText("Level "
                    + StageManager.Instance.StageNumber.ToString());

            yield return new WaitForSeconds(3f);

            End();
        }
    }
}
