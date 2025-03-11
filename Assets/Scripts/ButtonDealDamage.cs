using UnityEngine;
using UnityEngine.UI;

public class ButtonDealDamage : MonoBehaviour
{
    [SerializeField] private Health  _healthTarget;
    [SerializeField] private float _damageButton = 25;
    
    private Button _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(DealDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DealDamage);
    }

    private void DealDamage()
    {
        _healthTarget.TakeDamage(_damageButton);
    }
}