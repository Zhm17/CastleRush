using System.Collections;
using UnityEngine;

namespace CastleRush.UI
{
    public class UISInGame : UIStagePanel
    {
        protected override UI_STAGE_STATE m_state
            => UI_STAGE_STATE.INGAME;

        public override void Execute()
        {
            base.Execute();

            StageManager.Instance.StartMatch();
        }

        public void OnEndMatch()
        {
            StartCoroutine(EndMatchCoroutine());
        }

        IEnumerator EndMatchCoroutine()
        {
            yield return new WaitForSeconds(2f);

            End();
        }

    }
}
