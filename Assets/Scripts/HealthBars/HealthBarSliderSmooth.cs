using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HealthBars
{
    public class HealthBarSliderSmooth : HealthBar
    {
        [Range(5,10)][SerializeField] private int _speedChangingHeath;

        private float _maxSliderValue;
        private Slider _slider;
        private Coroutine _coroutine;

        protected override void Awake()
        {
            base.Awake();
            _slider = GetComponent<Slider>();
        }

        private void Start()
        {
            _maxSliderValue = Health.MaxPoints;
            _slider.maxValue = _maxSliderValue;
            _slider.value = _maxSliderValue;
            _slider.wholeNumbers = false;
        }
        
        protected override void OnHealthChange()
        {
            StartCoroutine(ChangeSliderSmooth());
        }
        
        private IEnumerator ChangeSliderSmooth()
        {
            while (!Mathf.Approximately(_slider.value, Health.CurrentPoints))
            {
                _slider.value = Mathf.MoveTowards(_slider.value, Health.CurrentPoints, Time.deltaTime *  _speedChangingHeath);
                
                yield return null;
            }
        }
    }
}