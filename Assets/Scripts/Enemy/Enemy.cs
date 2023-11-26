using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _health = 20;

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
