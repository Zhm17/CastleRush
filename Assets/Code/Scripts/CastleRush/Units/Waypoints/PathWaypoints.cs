using UnityEngine;

namespace CasteRush
{
    public class PathWaypoints : MonoBehaviour
    {
        public static Transform[] Points;

        void Awake()
        {
            Points = new Transform[transform.childCount];
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i] = transform.GetChild(i);
            }
        }
    }
}
