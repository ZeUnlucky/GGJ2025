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
        [SerializeField] private GameSettings _particleSystemSetting;
        [SerializeField] private UIManager _uiManager;

        private Vector3 _offset;
        private Camera _mainCamera;
        private bool _isDragging = false;
        private bool _gameActive = false;

        private void Awake()
        {
            _craftingSystem ??= FindAnyObjectByType<CraftingSystem>();
        }

        void Start()
        {
            _mainCamera = Camera.main;
            Cursor.lockState = CursorLockMode.Confined;
            _uiManager.OnMenuEnabled += SetGameStatus;
        }

        void OnMouseDown()
        {
            _offset = transform.position - GetMouseWorldPosition();
            if (!_isDragging)
                _uiManager.am.PlaySound(SoundIndexes.Click);
            _isDragging = true;
        }

        void OnMouseDrag()
        {
            if (_isDragging && _gameActive)
            {
                // Update the sprite's position to follow the mouse
                transform.position = GetMouseWorldPosition() + _offset;
            }
        }


        void OnMouseUp()
        {
            _isDragging = false;

            // Use OverlapCircle instead to find other objects
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.25f);

            foreach (Collider2D hit in hits)
            {
                // Skip self
                if (hit.gameObject == gameObject) continue;

                var thisTag = tag;
                var otherTag = hit.gameObject.tag;

                if (!_craftingSystem.TryToCombine(thisTag, otherTag, out GameObject output)) continue;

                GameObject.Instantiate(output, hit.gameObject.transform.position, quaternion.identity);
                GameObject.Instantiate(_particleSystemSetting.particleSystemObject, transform.position, quaternion.identity);
                if (_goalItem)
                {
                    _goalItem.Resolve();
                }

                Destroy(hit.gameObject);
                Destroy(gameObject);
                _uiManager.ItemsCombined();
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

        public void SetGameStatus(bool status)
        {
            _gameActive = !status;
        }

    }
}