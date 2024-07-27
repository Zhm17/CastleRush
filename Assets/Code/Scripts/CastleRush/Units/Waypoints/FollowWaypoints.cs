using System.Collections;
using UnityEngine;

namespace CastleRush.Units
{
    [RequireComponent(typeof(RotateTowardsTarget))]
    public class FollowWaypoints : MonoBehaviour
    {
        [Header("Target")]
        [SerializeField] private Transform m_currentTarget;
        private Transform CurrentTarget => m_currentTarget;
        public void SetCurrentTarget(Transform transform)
        {
            m_currentTarget = transform;
            if(TryGetComponent<RotateTowardsTarget>(out RotateTowardsTarget rttComponent))
            {
                rttComponent.SetTarget(CurrentTarget);
            }
        }

        [Header("Waypoint Index")]
        [SerializeField] private int m_currentWaypointIndex = 1;
        public int CurrentWaypointIndex => m_currentWaypointIndex;
        public void SetCurrentWaypointIndex(int currentWaypointIndex)
            => m_currentWaypointIndex = currentWaypointIndex;


        [Header("Walk Speed")]
        [SerializeField] private float m_startWalkSpeed = 5f;
        public float StartWalkSpeed => m_startWalkSpeed;
        public void SetStartWalkSpeed(float walkSpeed)
            => m_startWalkSpeed = walkSpeed;


        [SerializeField] private float m_walkSpeed = 5f;
        public float WalkSpeed => m_walkSpeed;
        public void SetWalkSpeed(float walkSpeed)
            => m_walkSpeed = walkSpeed;


        // Start is called before the first frame update
        public void StartWalking()
        {
            if(CurrentWaypointIndex > 1) 
                Reset();

            SetCurrentTarget(PathWaypoints.Points[CurrentWaypointIndex]);

            StartCoroutine(WalkCoroutine());
        }

        private void Reset()
        {
            SetWalkSpeed(StartWalkSpeed);
            SetCurrentWaypointIndex (1);
        }

        IEnumerator WalkCoroutine()
        {
            while(true)
            {
                Vector3 direction = CurrentTarget.position - transform.position;
                transform.Translate(direction.normalized * WalkSpeed * Time.deltaTime, Space.World);

                if (Vector3.Distance(transform.position, CurrentTarget.position) <= 0.4f)
                {
                    GetNextWaypoint();
                }

                yield return null;
            }
        }

        private void GetNextWaypoint()
        {
            if (CurrentWaypointIndex >= PathWaypoints.Points.Length - 1)
            {
                EndPath();
                return;
            }

            SetCurrentWaypointIndex(CurrentWaypointIndex + 1);
            SetCurrentTarget( PathWaypoints.Points[CurrentWaypointIndex]);
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
