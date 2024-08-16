using UnityEngine;
using UnityEngine.UI;
using Generics;
using CastleRush.Units;

namespace CastleRush.UI
{
    [RequireComponent(typeof(Slider))]
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField] public HealthType m_healthType;
        public HealthType Type
            => m_healthType;


        [Header("UI Resources")]
        private Slider m_lifeBarSlider;
        public Slider LifeBarSlider
            => m_lifeBarSlider = GetComponent<Slider>();
        public float SetSliderValue(int value)
            => m_lifeBarSlider.value 
                = (float) value;



        [Header("Min / Max")]
        [SerializeField] private int m_min = 0;
        public int Min 
            => m_min;
        public void SetMin(int value)
            => m_min = value;


        [SerializeField] private int m_max = 100;
        public int Max
            => m_max;
        public void SetMax(int value)
            => m_max = value;


        protected virtual void OnEnable()
        {
            HealthComponent.OnHealthUpdate += UpdateHealthBar;
        }

        protected virtual void OnDisable()
        {
            HealthComponent.OnHealthUpdate -= UpdateHealthBar;
        }

        protected virtual void OnDestroy()
        {
            HealthComponent.OnHealthUpdate -= UpdateHealthBar;
        }

        protected virtual void UpdateHealthBar(GameObject gameObject, 
                                                int value)
        {
            if (null == LifeBarSlider ||
                    !CheckType(gameObject) ||
                        value < Min)
                                return;

            SetSliderValue(value);
        }

        protected virtual bool CheckType(GameObject gameObject)
        {
            switch (Type)
            {
                case HealthType.HOME_BASE:
                    return gameObject.TryGetComponent(out CrystalPlatformBase platformBase);
                case HealthType.NPCENEMY:
                    return gameObject.TryGetComponent(out NPCEnemy enemy); 
            }

            return false;
        }
    }
}
