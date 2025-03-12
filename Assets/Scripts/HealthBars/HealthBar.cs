using UnityEngine;

namespace HealthBars
{
    public abstract class HealthBar :  MonoBehaviour
    {
        [SerializeField] private Health _health;

        protected Health Health => _health;
        
        protected virtual void Awake()
        {
            if (_health == null)
                return;

            _health.Changed += OnHealthChange;
        }

        private void OnDestroy()
        {
            if (_health == null)
                return;
            
            _health.Changed -= OnHealthChange;
        }

        protected abstract void OnHealthChange();
    }
}