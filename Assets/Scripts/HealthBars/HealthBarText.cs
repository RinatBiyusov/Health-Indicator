using System;
using TMPro;
using UnityEngine;

namespace HealthBars
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class HealthBarText : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private TextMeshProUGUI _healthText;

        private void Awake()
        {
            _healthText = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            _health.OnHealthChanged += ChangeHealth;
        }

        private void Start()
        {
            ChangeHealthsText();
        }
        
        private void OnDisable()
        {
            _health.OnHealthChanged -= ChangeHealth;
        }
        
        private void ChangeHealth()
        {
            ChangeHealthsText();
        }

        private void ChangeHealthsText() => _healthText.text = $"{_health.CurrentHealth}/{_health.MaxHealth}";
    }
}