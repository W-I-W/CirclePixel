using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace PixelGame.Touch
{
    public class SystemTouch : MonoBehaviour, IPointerClickHandler
    {

        public static UnityAction<Vector2> OnClick { get; set; }


        public void OnPointerClick(PointerEventData eventData)
        {
            Vector2 worldPosition = eventData.pointerCurrentRaycast.worldPosition;
            OnClick?.Invoke(worldPosition);
        }
    }
}
