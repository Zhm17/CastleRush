using UnityEngine;
using UnityEngine.EventSystems;

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

        [Header("Interaction")]
        [SerializeField] protected Canvas m_interactiveCanvas;
        public Canvas InteractiveCanvas => m_interactiveCanvas;


        protected virtual void Start()
        {
            InitialLocalPosition = transform.localPosition;
        }

        public virtual void OnDrag(PointerEventData data)
        {
            SetOnAction(true);

            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                (RectTransform)InteractiveCanvas.transform,
                data.position,
                InteractiveCanvas.worldCamera,
                out Vector2 position);

            transform.position = InteractiveCanvas.transform.TransformPoint(position);
        }

        public virtual void OnDrop(PointerEventData data)
        {
            SetOnAction(false);

            transform.localPosition = InitialLocalPosition;
        }
    }
}
