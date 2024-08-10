using CastleRush.BGM;

namespace CastleRush.UI
{
    public class UISYouWon : UIStagePanel
    {
        protected override UI_STAGE_STATE m_state
            => UI_STAGE_STATE.YOU_WON;

        public override void Execute()
        {
            base.Execute();
            BGMManager.Instance.PlayGameVictoryMusic();
        }
    }
}
