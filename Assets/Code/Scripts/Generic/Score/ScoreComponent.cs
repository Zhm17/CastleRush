using UnityEngine;

namespace Generics
{
    public class ScoreComponent : MonoBehaviour
    {
        public delegate void UpdateScore(int value = 0);
        public static event UpdateScore OnUpdateScore;

        public delegate void HighScoreReach();
        public static event HighScoreReach OnHighScoreReached;


        [SerializeField] protected int m_currentValue = 0;
        public int CurrentValue
            => m_currentValue; 
        public int SetScoreValue(int value) 
            => m_currentValue = value;

        
        [SerializeField] protected int m_goalScoreValue = 5;
        public int GoalScoreValue
            => m_goalScoreValue; 
        public int SetGoalScoreValue(int value)
            => m_goalScoreValue = value;


        public void Reset()
        {
            SetScoreValue(0);
            ValueUpdatedNotification();
        }

        public virtual void Scored(int scoreValue)
        {
            SetScoreValue( CurrentValue + scoreValue );
            ValueUpdatedNotification();
        }

        protected virtual void ValueUpdatedNotification()
        {
            // Notify
            if (OnUpdateScore != null)
                    OnUpdateScore(CurrentValue);

            if(CurrentValue >= GoalScoreValue 
               && OnHighScoreReached != null )
                    OnHighScoreReached();
        }
    }
}
