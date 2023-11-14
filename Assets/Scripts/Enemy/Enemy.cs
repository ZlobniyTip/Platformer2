using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _pursuitDistance;
    [SerializeField] private float _attackDistance;

    public Player Target => _target;
    public float PursuitDistance => _pursuitDistance;
    public float AttackDistance => _attackDistance;

    private int _damage = 10;
    private int _health = 20;

    public void Attack()
    {
        _target.TakeDamage(_damage);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
