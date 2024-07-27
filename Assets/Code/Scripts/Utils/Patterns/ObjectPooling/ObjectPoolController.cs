using UnityEngine;
using UnityEngine.Pool;

namespace Utils
{
    public abstract class ObjectPoolController : MonoBehaviour
    {
        [Header("Capacity")]
        [SerializeField] protected int m_maxPoolSize = 15;
        public int MaxPoolSize 
            => m_maxPoolSize;
        public void SetMaxPoolSize(int maxPoolSize)
            => m_maxPoolSize = maxPoolSize;
        

        // POSITION TO SPAWN
        [Header("Spawn Point Position")]
        [SerializeField] protected Vector3 m_spawnPoint;
        public Vector3 SpawnPoint => m_spawnPoint;
        public virtual void SetSpawnPoint(Vector3 position)
            => m_spawnPoint = position;


        [Header("Parent")]
        [SerializeField] protected Transform m_spawnerParent;
        public Transform SpawnerParent => m_spawnerParent;
        public virtual void SetSpawnerParent(Transform parent)
            => m_spawnerParent = parent;


        [SerializeField] protected int m_stackDefaultCapacity = 15;
        public int StackDefaultCapacity => m_stackDefaultCapacity;
        public virtual void SetStackDefaultCapacity(int stackDefaultCapacity)
            => m_stackDefaultCapacity = stackDefaultCapacity;


        [Header("List")]
        [SerializeField] protected ItemPool m_itemPrefab;
        public ItemPool ItemPrefab => m_itemPrefab;
        public virtual void SetItemPrefab(ItemPool item)
            => m_itemPrefab = item;

        

        // OBJECT POOL
        protected IObjectPool<ItemPool> m_pool;
        public virtual IObjectPool<ItemPool> Pool
        {
            get
            {
                if (null == m_pool )
                    m_pool =
                        new ObjectPool<ItemPool>(
                            CreatedPooledItem,
                            OnTakeFromPool,
                            OnReturnedToPool,
                            OnDestroyPoolObject,
                            true,
                            StackDefaultCapacity,
                            MaxPoolSize);
                return m_pool;
            }
        }




#region POOL METHODS
        protected virtual ItemPool CreatedPooledItem()
        {
            ItemPool newItem = Instantiate(ItemPrefab,
                                        SpawnPoint,
                                        Quaternion.identity);

            newItem.SetPool(Pool);
            newItem.transform.parent = SpawnerParent;

            return newItem;
        }

        protected virtual void OnReturnedToPool(ItemPool item)
        {
            item.gameObject.SetActive(false);
        }

        protected virtual void OnTakeFromPool(ItemPool item)
        {
            item.transform.position = SpawnPoint;
            item.gameObject.SetActive(true);
        }

        protected virtual void OnDestroyPoolObject(ItemPool item)
        {
            Destroy(item.gameObject);
        }

#endregion


    }
}
