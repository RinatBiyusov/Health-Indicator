using UnityEngine;
using UnityEngine.UI;

public class ButtonHeal : MonoBehaviour
{
    [SerializeField] private Health  _healthTarget;
    [SerializeField] private float _healPoints = 25;
    
    private Button _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(HealTarget);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(HealTarget);
    }

    private void HealTarget()
    {
        _healthTarget.TryTakeHeal(_healPoints);
    }
}