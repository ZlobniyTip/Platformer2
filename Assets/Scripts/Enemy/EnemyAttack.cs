using UnityEngine;

public class EnemyAttack : Enemy
{
    [SerializeField] private Player _target;
    [SerializeField] private float _pursuitDistance;
    [SerializeField] private float _attackDistance;

    public float DelayBetweenAttacks { get; private set; } = 3;
    public float TimeLastHit { get; private set; } = 0;

    public Player Target => _target;
    public float PursuitDistance => _pursuitDistance;
    public float AttackDistance => _attackDistance;

    private int _damage = 10;

    private void Update()
    {
        TimeLastHit += Time.deltaTime;

        if (TimeLastHit >= DelayBetweenAttacks)
        {
            if (Vector2.Distance(transform.position, Target.transform.position) < AttackDistance)
            {
                Attack();
                TimeLastHit = 0;
            }
        }
    }

    public void Attack()
    {
        _target.TakeDamage(_damage);
    }
}
