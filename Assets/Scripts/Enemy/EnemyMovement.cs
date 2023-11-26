using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private EnemyAttack _attack;
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

        if (Vector2.Distance(transform.position, _attack.Target.transform.position) < _attack.PursuitDistance)
        {
            ChasePlayer();
        }
        else
        {
            Patrol(target);
        }
    }

    private void Patrol(Transform target)
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

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _attack.Target.transform.position, _speed * Time.deltaTime);
    }
}