using UnityEngine;
using UnityEngine.EventSystems;

using Generics;
using CastleRush.Units;

namespace CastleRush.UI 
{
    public class WTurretSpawnDragButton : DragButton
    {
        private Camera MainCamera 
            => Camera.main;

        [SerializeField] public WTurretType Type 
            = WTurretType.DEFAULT;

        public override void OnDrop(PointerEventData data)
        {
            base.OnDrop(data);

            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

            int layerMask = 8;
            layerMask = ~layerMask;

            if (Physics.Raycast(ray, 
                out RaycastHit hit, 
                Mathf.Infinity, 
                layerMask)
                )
            {
                if (hit.transform.TryGetComponent(out TowerSpot tower))
                    tower.SetTurret(
                        WTurretFactory.Instance.CreateNSet(
                            Type, Vector3.zero
                            )
                        );
            }
        }
    }
}
