using UnityEngine;
using Utils;

namespace CastleRush.Units
{
    [RequireComponent(typeof(Animator), typeof(FollowWaypoints))]
    public abstract class NPCEnemy : ItemPool
    {
        [Header("NPC Enemy Properties")]
        [SerializeField] protected EnemyType m_type;
        public abstract EnemyType Type();


        protected Animator Animator => GetComponent<Animator>();
        protected FollowWaypoints PathWalker => GetComponent<FollowWaypoints>();



        protected override void OnEnable()
        {
            base.OnEnable();
            Active();
        }

        protected virtual void Active() 
        {
            PathWalker?.StartWalking();
        }

        protected virtual void Hit() 
        { 
            // TODO Notify Hit
            // TODO Get Damage
        }

        protected virtual void Die() 
        {
            Animator.SetBool("Dead", true);
        }

        protected virtual void Sleep() {
            gameObject.SetActive(false);
        }

    }
}
