using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    private readonly float _deathHealth = 0;

    [SerializeField] private float _maxHealth;

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; }

    public event Action OnHealthChanged;

    private void Awake()
    {
        CurrentHealth = _maxHealth;
        MaxHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (CurrentHealth <= damage)
            CurrentHealth = _deathHealth;
        else
            CurrentHealth -= damage;

        OnHealthChanged?.Invoke();
    }

    public void TryTakeHeal(float heal)
    {
        if (CurrentHealth + heal >= _maxHealth)
            CurrentHealth = _maxHealth;
        else
            CurrentHealth += heal;

        OnHealthChanged?.Invoke();
    }
}