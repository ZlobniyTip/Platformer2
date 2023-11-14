using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _attackDistance;

    private Enemy _currentTarget;
    private int _currentHealth;
    private int _currentCoins;

    private void Start()
    {
        _currentHealth = _health;
    }

    private void Update()
    {
        
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
            Destroy(collision.gameObject);
        }
    }

    private void Attack()
    {
        _currentTarget.TakeDamage(_damage);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
    }
}
