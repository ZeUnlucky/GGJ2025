using System;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime
{
    [RequireComponent(typeof(Collider2D))]
    public class DragAndDrop : MonoBehaviour
    {
        [SerializeField] private CraftingSystem _craftingSystem;
        [SerializeField] private GoalItem _goalItem;

        private Vector3 _offset;
        private Camera _mainCamera;
        private bool _isDragging = false;

        private void Awake()
        {
            _craftingSystem ??= FindAnyObjectByType<CraftingSystem>();
        }

        void Start()
        {
            _mainCamera = Camera.main;
        }

        void OnMouseDown()
        {
            _offset = transform.position - GetMouseWorldPosition();
            _isDragging = true;
        }

        void OnMouseDrag()
        {
            if (_isDragging)
            {
                // Update the sprite's position to follow the mouse
                transform.position = GetMouseWorldPosition() + _offset;
            }
        }


        void OnMouseUp()
        {
            _isDragging = false;

            // Use OverlapCircle instead to find other objects
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 5f);

            foreach (Collider2D hit in hits)
            {
                // Skip self
                if (hit.gameObject == gameObject) continue;

                var thisTag = tag;
                var otherTag = hit.gameObject.tag;

                if (!_craftingSystem.TryToCombine(thisTag, otherTag, out GameObject output)) continue;

                GameObject.Instantiate(output, transform.position, quaternion.identity);

                if (_goalItem)
                {
                    _goalItem.Resolve();
                }

                Destroy(hit.gameObject);
                Destroy(gameObject);
                // Exit after first successful combination
                break;
            }
        }

        private Vector3 GetMouseWorldPosition()
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = _mainCamera.WorldToScreenPoint(transform.position).z;
            return _mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        }
    }
}