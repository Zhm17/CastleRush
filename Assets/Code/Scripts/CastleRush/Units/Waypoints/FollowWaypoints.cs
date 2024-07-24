using System.Collections;
using UnityEngine;

namespace CasteRush
{
    public class FollowWaypoints : MonoBehaviour
    {
        private Transform m_currentTarget;
        private int m_currentWaypointIndex = 0;

        private float m_startSpeed = 10f;
        private float m_walkSpeed = 5f;

        // Start is called before the first frame update
        void Start()
        {
            m_currentTarget = PathWaypoints.Points[0];
            StartCoroutine(WalkCoroutine());
        }

        IEnumerator WalkCoroutine()
        {
            while(true)
            {
                Vector3 dir = m_currentTarget.position - transform.position;
                transform.Translate(dir.normalized * m_walkSpeed * Time.deltaTime, Space.World);

                if (Vector3.Distance(transform.position, m_currentTarget.position) <= 0.4f)
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
            m_currentTarget = PathWaypoints.Points[m_currentWaypointIndex];
        }

        private void EndPath()
        {
            //TODO Notify End Path
            StopAllCoroutines();
        }

    }
}
