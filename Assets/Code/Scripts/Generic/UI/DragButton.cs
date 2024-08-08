using UnityEngine;
using UnityEngine.EventSystems;
using CastleRush.UI;

namespace Generics
{
    public class DragButton : MonoBehaviour, IDragHandler, IDropHandler
    {
        protected Vector2 InitialLocalPosition;
        
        [SerializeField] protected bool m_onAction;
        public bool OnAction
            => m_onAction;
        protected void SetOnAction(bool flag)
            => m_onAction = flag;

        protected Canvas StageCanvas 
            => UIManager.Instance.StageCanvas;


        protected virtual void Start()
        {
            InitialLocalPosition = transform.localPosition;
        }

        public virtual void OnDrag(PointerEventData data)
        {
            SetOnAction(true);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)StageCanvas.transform,
                data.position,
                StageCanvas.worldCamera,
                out Vector2 position);

            transform.position = StageCanvas.transform.TransformPoint(position);
        }

        public virtual void OnDrop(PointerEventData data)
        {
            SetOnAction(false);

            transform.localPosition = InitialLocalPosition;
        }
    }
}
