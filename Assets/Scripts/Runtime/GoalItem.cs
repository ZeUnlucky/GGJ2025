using System;
using UnityEngine;

namespace Runtime
{
    public class GoalItem : MonoBehaviour
    {
        [SerializeField] private GoalManager _goalManager;
        private bool _isResolved = false;
        public event Action<GoalItem> OnResolved;

        private void Awake()
        {
            _goalManager ??= FindAnyObjectByType<GoalManager>();
        }

        private void Start()
        {
            _goalManager.Add(this);
            _isResolved = false;
        }

        public void Resolve()
        {
            if (_isResolved) return;
            _isResolved = true;
            OnResolved?.Invoke(this);
        }
    }
}