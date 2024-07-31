using UnityEngine;

namespace Utils
{
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {

        // Game Instance Singleton
        private static T m_instance = null;
        public static T Instance => m_instance;

        private void Awake()
        {
            if (null == m_instance)
            {
                m_instance = this as T;
                m_instance.Init();
            }
            else if (m_instance != (this as T))
            {
                DestroyImmediate(this);
                return;
            }
        }

        protected virtual void OnDestroy()
        {
            if ((this as T) == m_instance)
            {
                m_instance = null;
            }
        }

        protected abstract void Init();

    }
}
