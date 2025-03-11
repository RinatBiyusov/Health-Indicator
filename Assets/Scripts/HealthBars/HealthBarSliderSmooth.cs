using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HealthBars
{
    public class HealthBarSliderSmooth : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [Range(5,10)][SerializeField] private int _speedChangingHeath;

        private float _maxSliderValue;
        private Slider _slider;
        private Coroutine _coroutine;

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
            _health.OnHealthChanged -= ChangeHealthSlider;
        }

        private void ChangeHealthSlider()
        {
            StartCoroutine(ChangeSliderSmooth());
        }

        private IEnumerator ChangeSliderSmooth()
        {
            while (!Mathf.Approximately(_slider.value, _health.CurrentHealth))
            {
                _slider.value = Mathf.MoveTowards(_slider.value, _health.CurrentHealth, Time.deltaTime *  _speedChangingHeath);
                
                yield return null;
            }
        }
    }
}