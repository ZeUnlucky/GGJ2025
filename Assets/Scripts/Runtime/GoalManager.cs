﻿using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Runtime
{
    public class GoalManager : MonoBehaviour
    {
        [SerializeField] private List<GoalItem> _goalItems;
        [SerializeField] private TextMeshProUGUI _textFieldPrefab;

        public List<GoalItem> GoalItems => _goalItems;
        public int Score { get; private set; } = 0;

        public void Add(GoalItem goalItem)
        {
            _goalItems.Add(goalItem);
            var instance = GameObject.Instantiate(_textFieldPrefab, transform);
            instance.text = goalItem.name;

            goalItem.OnResolved += item =>
            {
                _goalItems.Remove(item);
                Score++;
                //instance.text = $"<s>{instance.text}</s>";
                Destroy(instance);
            };
        }
    }
}