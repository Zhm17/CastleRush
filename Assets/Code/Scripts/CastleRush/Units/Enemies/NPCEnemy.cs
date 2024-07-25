using CastleRush.Units;
using UnityEngine;
using Utils;

namespace CasteRush.Units
{
    [RequireComponent(typeof(Animator), typeof(FollowWaypoints))]
    public class NPCEnemy : ItemPool
    {

        public EnemyType Type => EnemyType.TEST;


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
