using CastleRush.BGM;

namespace CastleRush.UI
{
    public class UISGameOver : UIStagePanel
    {
        protected override UI_STAGE_STATE m_state
            => UI_STAGE_STATE.GAMEOVER;

        public override void Execute()
        {
            base.Execute();
            BGMManager.Instance.PlayGameOverMusic();
        }
    }
}
