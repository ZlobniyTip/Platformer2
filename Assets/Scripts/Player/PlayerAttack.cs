using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private LayerMask _damageble;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackDistance;
    [SerializeField] private int _damage;

    private float _timeBetweenAttack = 2;
    private float _timer;

    private void Update()
    {
        Attack();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _attackDistance);
    }

    private void Attack()
    {
        if (_timer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackDistance, _damageble);

                if (enemies.Length != 0)
                {
                    for (int i = 0; i < enemies.Length; i++)
                    {
                        enemies[i].GetComponent<Enemy>().TakeDamage(_damage);
                    }
                }

                _timer = _timeBetweenAttack;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}