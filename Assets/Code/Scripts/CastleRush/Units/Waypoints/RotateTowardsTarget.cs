using UnityEngine;

namespace CastleRush.Units
{
    public class RotateTowardsTarget : MonoBehaviour
    {
        [SerializeField] private float m_rotationSpeed = 100f;
        private float RotationSpeed =>  m_rotationSpeed;


        [SerializeField] private Transform m_target;
        public Transform Target => m_target;
        public void SetTarget(Transform target)
        {
            m_target = target;
            LookToTarget();
        }

        public void LookToTarget()
        {
            if (null == Target) return;

            Vector3 direction =
                (Target.position - transform.position).normalized;

            Quaternion lookRotation =
                Quaternion.LookRotation(
                                    new Vector3(direction.x,
                                                    0f,
                                                    direction.z)
                                    );

            transform.rotation =
                Quaternion.Slerp(transform.rotation,
                                    lookRotation,
                                    Time.deltaTime * RotationSpeed);
        }

    }
}
