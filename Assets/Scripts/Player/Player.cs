using UnityEngine;

public class Player : Health
{
    private int _currentCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _currentCoins++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Cherry cherry))
        {
            Heal(cherry.Heal());
            Destroy(collision.gameObject);
        }
    }
}
