using UnityEngine;

namespace Runtime
{
    public class DragAndDrop : MonoBehaviour
    {
        private Vector3 offset;
        private Camera mainCamera;
        private bool isDragging = false;

        void Start()
        {
            mainCamera = Camera.main;
        }

        void OnMouseDown()
        {
            offset = transform.position - GetMouseWorldPosition();
            isDragging = true;
        }

        void OnMouseDrag()
        {
            if (isDragging)
            {
                // Update the sprite's position to follow the mouse
                transform.position = GetMouseWorldPosition() + offset;
            }
        }

        void OnMouseUp()
        {
            isDragging = false;
        }

        private Vector3 GetMouseWorldPosition()
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = mainCamera.WorldToScreenPoint(transform.position).z;
            return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        }
    }
}