using UnityEngine;
using UnityEngine.SceneManagement;

namespace CastleRush.UI
{
    public abstract class UIStagePanel : MonoBehaviour
    {
        public delegate void StateAction(UI_STAGE_STATE state);
        public static event StateAction OnStartUISState;
        public static event StateAction OnEndUISState;

        protected virtual UI_STAGE_STATE m_state 
            => UI_STAGE_STATE.DEFAULT;
        public UI_STAGE_STATE State
            => m_state;

        protected virtual void OnEnable()
        {
            
        }

        protected virtual void OnDisable()
        {
            StopAllCoroutines();
        }

        protected virtual void OnDestroy()
        {
            StopAllCoroutines();
        }

        public virtual void Execute ()
        {
            Show();

            if(OnStartUISState != null)
                OnStartUISState(State);
        }

        public virtual void Show()
        {
            if (!gameObject.activeInHierarchy)
                gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            if (gameObject.activeInHierarchy)
                gameObject.SetActive(false);
        }

        public virtual void BackToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public virtual void ReloadStage()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public virtual void NextStage()
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            int nextStageIndex = (index == 0)? 1 : index + 1;
            
            if (nextStageIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextStageIndex);
                return;
            }

            BackToMainMenu();
        }

        public virtual void End()
        {
            if(OnEndUISState != null) 
                OnEndUISState(State);

            Hide();
        }
    }
}
