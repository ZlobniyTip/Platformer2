using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _path;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _speed;

    private SpriteRenderer _spriteRenderer;
    private int _currentPoint;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        if (Vector2.Distance(transform.position, _enemy.Target.transform.position) < _enemy.PursuitDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, _enemy.Target.transform.position, _speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, _enemy.Target.transform.position) < _enemy.AttackDistance)
            {
                _enemy.Attack();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

            if (transform.position == target.position)
            {
                _currentPoint++;
                _spriteRenderer.flipX = !_spriteRenderer.flipX;

                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }
            }
        }
    }
}