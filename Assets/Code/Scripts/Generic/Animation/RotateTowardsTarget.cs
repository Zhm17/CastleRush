using System.Collections;
using UnityEngine;

namespace Generics
{
    public class RotateTowardsTarget : MonoBehaviour
    {
        [SerializeField] private float m_rotationSpeed = 100f;
        private float RotationSpeed 
            =>  m_rotationSpeed;


        [SerializeField] private Transform m_target;
        public Transform Target 
            => m_target;
        public void SetTarget(Transform target)
        {
            m_target = target;
        }

        private void OnEnable()
        {
            StartCoroutine(Look2TargetCoroutine());
        }

        public void LookToTarget()
        {
            if (null == Target) 
                return;

            Vector3 direction =
                (Target.position - 
                 transform.position).normalized;

            Quaternion lookRotation =
                Quaternion.LookRotation(
                    new Vector3(
                        direction.x, 
                        0f, 
                        direction.z));

            transform.rotation =
                Quaternion.Slerp(
                    transform.rotation,
                    lookRotation,
                    RotationSpeed * Time.deltaTime);
        }

        IEnumerator Look2TargetCoroutine()
        {
            while (true)
            {
                LookToTarget();

                yield return null;
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }



    }
}
