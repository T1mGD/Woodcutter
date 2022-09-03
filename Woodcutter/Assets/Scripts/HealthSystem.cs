using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public UnityEvent DiyngEvent;
    [SerializeField] private UnityEvent ChangeHealthEvent;
    [SerializeField] private int _health;
    public int MaxHealth { get; private set; }
    public int Health => _health;

    private void OnEnable ()
    {
        MaxHealth = _health;
    }

    public void ApplyDamage(int damageAmount)
    {
        _health -= damageAmount;

        if (_health <= 0)
        {
            _health = 0;
            Die();
        }

        ChangeHealthEvent.Invoke();
    }

    public void ApplyHeal(int healAmount)
    {
        _health += healAmount;

        if (_health > MaxHealth)
        {
            _health = MaxHealth;
        }

        ChangeHealthEvent.Invoke();
    }

    private void Die()
    {
        DiyngEvent.Invoke();
        Destroy(gameObject);
    }
}
