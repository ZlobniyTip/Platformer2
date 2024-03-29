using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Heal(int healValue)
    {
        if (_currentHealth + healValue <= _maxHealth)
        {
            _currentHealth += healValue;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }
    }
}
