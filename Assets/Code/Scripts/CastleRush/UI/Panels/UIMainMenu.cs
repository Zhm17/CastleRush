using CastleRush.BGM;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CastleRush.UI
{
    public class UIMainMenu : MonoBehaviour
    {
        private void Start()
        {
            BGMManager.Instance.PlayMainMenuMusic();
        }

        public void Play()
        {
            int index = SceneManager.GetActiveScene().buildIndex;
            int nextStageIndex = (index == 0) ? 1 : index + 1;

            SceneManager.LoadScene(nextStageIndex);
        }
    }
}
