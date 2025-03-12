using UnityEngine;
using System;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private float _max;
    
    private readonly float _death = 0;
    
    public event Action Changed;
    
    public float CurrentPoints { get; private set; }
    public float MaxPoints { get; private set; }
    
    private void Awake()
    {
        CurrentPoints = _max;
        MaxPoints = _max;
    }

    public void TakeDamage(float damage)
    {
        if (CurrentPoints <= damage)
            CurrentPoints = _death;
        else
            CurrentPoints -= damage;

        Changed?.Invoke();
    }

    public void Heal(float heal)
    {
        if (CurrentPoints + heal >= _max)
            CurrentPoints = _max;
        else
            CurrentPoints += heal;

        Changed?.Invoke();
    }
}