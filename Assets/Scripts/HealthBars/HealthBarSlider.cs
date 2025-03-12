using UnityEngine;
using UnityEngine.UI;

namespace HealthBars
{
    [RequireComponent(typeof(Slider))]
    public class HealthBarSlider : HealthBar
    {
        private float _maxSliderValue;
        private Slider _slider;

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
            _slider.value = Health.CurrentPoints;
        }
    }
}
