using UnityEngine;
using Utils;

namespace CastleRush.BGM
{
    [RequireComponent(typeof(AudioSource))]
    public class BGMManager : Singleton<BGMManager>
    {
        public AudioSource AudioSource 
            => GetComponent<AudioSource>();

        [Header("Main Menu BGM")]
        [SerializeField] private AudioClip m_mainMenuAC;
        public AudioClip MainMenuAC 
            => m_mainMenuAC;

        [Header("In Game BGM")]
        [SerializeField] private AudioClip m_inGameAC;
        public AudioClip InGameAC 
            => m_inGameAC;
        [SerializeField] private AudioClip m_gameOverAC;
        public AudioClip GameOverAC 
            => m_gameOverAC;
        [SerializeField] private AudioClip m_gameVictoryAC;
        public AudioClip GameVictoryAC 
            => m_gameVictoryAC;

        protected override void Init()
        {
            
        }

        public void PlayMainMenuMusic()
        {
            if (null == MainMenuAC)
                return;

            AudioSource.clip = MainMenuAC;
            AudioSource.Play();
        }

        public void PlayInGameMusic()
        {
            if (null == InGameAC)
                return;

            AudioSource.clip = InGameAC;
            AudioSource.Play();
        }

        public void PlayGameOverMusic()
        {
            if (null == GameOverAC)
                return;

            AudioSource.clip = GameOverAC;
            AudioSource.Play();
        }

        public void PlayGameVictoryMusic()
        {
            if (null == GameVictoryAC)
                return;

            AudioSource.clip = GameVictoryAC;
            AudioSource.Play();
        }


    }

}
