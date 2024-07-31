using UnityEngine;

namespace CastleRush.Units
{
    public class PathWaypoints : MonoBehaviour
    {
        protected static Transform[] s_points;
        public static Transform[] Points 
            => s_points;
        public void SetTPointsArray(int length)
            => s_points = new Transform[length];
        

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
