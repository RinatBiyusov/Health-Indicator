using UnityEngine;
using UnityEngine.UI;

namespace HealthBars
{
    [RequireComponent(typeof(Slider))]
    public class HealthBarSlider : MonoBehaviour
    {
        [SerializeField] private Health _health;

        private float _maxSliderValue;
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            _health.OnHealthChanged += ChangeHealthSlider;
        }

        private void Start()
        {
            _maxSliderValue = _health.MaxHealth;
            _slider.maxValue = _maxSliderValue;
            _slider.value = _maxSliderValue;
            _slider.wholeNumbers = false;
        }

        private void OnDisable()
        {
            _health.OnHealthChanged += ChangeHealthSlider;
        }

        private void ChangeHealthSlider()
        {
            _slider.value = _health.CurrentHealth;
        }
    }
}
