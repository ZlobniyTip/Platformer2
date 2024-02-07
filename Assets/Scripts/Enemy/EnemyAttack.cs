using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _pursuitDistance;
    [SerializeField] private float _attackDistance;

    private Coroutine _attack;

    private float _delayBetweenAttack = 2;

    public Player Target => _target;
    public float PursuitDistance => _pursuitDistance;
    public float AttackDistance => _attackDistance;

    private int _damage = 10;

    private void Start()
    {
        _attack = StartCoroutine(TryAttack());
    }

    public void Attack()
    {
        _target.TakeDamage(_damage);
    }

    private IEnumerator TryAttack()
    {
        var DelayBetweenAttack = new WaitForSeconds(_delayBetweenAttack);

        while (true)
        {
            if (Vector2.Distance(transform.position, _target.transform.position) < _attackDistance)
            {
                Attack();
            }

            yield return DelayBetweenAttack;
        }
    }
}
