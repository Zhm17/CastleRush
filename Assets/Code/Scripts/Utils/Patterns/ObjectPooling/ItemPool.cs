using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace Utils
{
    public abstract class ItemPool : MonoBehaviour
    {
        // TODO Move this attribute of class
        [Header("Item Properties")]
        [SerializeField] int m_id;
        public int ID => m_id;
        public void SetID(int id)
        {
            m_id = id;
        }

        [SerializeField] protected IObjectPool<ItemPool> m_pool;
        public IObjectPool<ItemPool> Pool => m_pool;
        public virtual void SetPool(IObjectPool<ItemPool> pool)
        {
            m_pool = pool;
        }

        [Header("Life")]
        [SerializeField] protected float m_lifeTime = 10f;
        public float LifeTime => m_lifeTime;
        public virtual void SetLifeTime(float lifeTime)
        {
            m_lifeTime = lifeTime;
        }

        // Start is called before the first frame update
        protected virtual void OnEnable()
        {
            if (m_lifeTime > -1)
                StartCoroutine(SelfDestruct());
        }

        protected virtual void OnDisable()
        {
            StopAllCoroutines();

            ReturnToPool();
        }

        protected virtual void OnDestroy()
        {
            StopAllCoroutines();

            ReturnToPool();
        }

        protected virtual IEnumerator SelfDestruct()
        {
            yield return new WaitForSeconds(LifeTime);
            ReturnToPool();
        }

        public virtual void ReturnToPool()
        {
            if (!gameObject.activeInHierarchy)
                return;

            if (null == Pool)
            {
                gameObject.SetActive(false);
                return;
            }

            Pool.Release(this);
        }
    }
}
