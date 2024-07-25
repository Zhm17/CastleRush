using UnityEngine;

namespace CastleRush.Units
{
    public class PathWaypoints : MonoBehaviour
    {
        protected static Transform[] m_points;
        public static Transform[] Points => m_points;
        public void SetTPointsArray(int length)
        {
            m_points = new Transform[length];
        }

        protected virtual void Awake()
        {
            SetTPointsArray(transform.childCount);

            for (int i = 0; i < Points.Length; i++)
            {
                Points[i] = transform.GetChild(i);
            }
        }
    }
}
