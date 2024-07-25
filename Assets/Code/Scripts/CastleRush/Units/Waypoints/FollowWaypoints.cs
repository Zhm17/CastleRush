using CastleRush.Units;
using System.Collections;
using UnityEngine;

namespace CasteRush.Units
{
    [RequireComponent(typeof(RotateTowardsTarget))]
    public class FollowWaypoints : MonoBehaviour
    {
        [SerializeField] private Transform m_currentTarget;
        private Transform CurrentTarget => m_currentTarget;
        private void SetCurrentTarget(Transform transform)
        {
            m_currentTarget = transform;
            if(TryGetComponent<RotateTowardsTarget>(out RotateTowardsTarget rtt))
            {
                rtt.SetTarget(CurrentTarget);
            }
        }


        [SerializeField] private int m_currentWaypointIndex = 0;

        [SerializeField] private float m_startSpeed = 5f;
        [SerializeField] private float m_walkSpeed = 5f;

        // Start is called before the first frame update
        public void StartWalking()
        {
            SetCurrentTarget( PathWaypoints.Points[0]);
            
            if(m_currentWaypointIndex > 0 ) 
                Reset();
            
            StartCoroutine(WalkCoroutine());
        }

        private void Reset()
        {
            m_currentWaypointIndex = 0;
        }

        IEnumerator WalkCoroutine()
        {
            while(true)
            {
                Vector3 direction = CurrentTarget.position - transform.position;
                transform.Translate(direction.normalized * m_walkSpeed * Time.deltaTime, Space.World);

                if (Vector3.Distance(transform.position, CurrentTarget.position) <= 0.4f)
                {
                    GetNextWaypoint();
                }

                m_walkSpeed = m_startSpeed;

                yield return null;
            }
        }

        private void GetNextWaypoint()
        {
            if (m_currentWaypointIndex >= PathWaypoints.Points.Length - 1)
            {
                EndPath();
                return;
            }

            m_currentWaypointIndex++;
            SetCurrentTarget( PathWaypoints.Points[m_currentWaypointIndex]);
        }

        private void EndPath()
        {
            //TODO Notify End Path

            //Shutdown object
            StopAllCoroutines();
            gameObject.SetActive(false);
        }

        

    }
}
