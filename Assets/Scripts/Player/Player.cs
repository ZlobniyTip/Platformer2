using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;

    private int _currentCoins;
    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    public int MaxHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _currentCoins++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Cherry cherry))
        {
            _currentHealth += cherry.Heal();
            HealthChanged?.Invoke(_currentHealth, _maxHealth);
            Destroy(collision.gameObject);
        }
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
}
