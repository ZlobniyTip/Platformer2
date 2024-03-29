using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Vampirism _spell;
    [SerializeField] private LayerMask _damageble;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _spellDistance;
    [SerializeField] private float _attackDistance;
    [SerializeField] private int _damage;

    private float _timeBetweenAttack = 2;
    private float _timer;

    public bool ShouldAttack { get; private set; } = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ActivateVampirism();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            _spell.DeactivateSpell();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_attackPoint.position, _spellDistance);
    }

    private void ActivateVampirism()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackDistance, _damageble);

        if (enemies.Length != 0)
        {
            foreach (var target in enemies)
            {
                _spell.ActivateSpell(target);
            }
        }
    }

    private void Attack()
    {
        if (_timer <= 0)
        {
            ShouldAttack = true;
            ShouldAttack = false;

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
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}