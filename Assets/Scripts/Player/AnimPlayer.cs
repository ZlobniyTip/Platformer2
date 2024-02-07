using UnityEngine;

[RequireComponent(typeof(Animation))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAttack))]
public class AnimPlayer : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _movement;
    private PlayerAttack _attack;

    public class Params
    {
        public static readonly int Speed = Animator.StringToHash(nameof(Speed));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
        _attack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        SetupAnimation(_movement.CurrentSpeed, _attack.ShouldAttack);
    }

    private void SetupAnimation(float speed, bool shouldAttack)
    {
        _animator.SetFloat(Params.Speed, Mathf.Abs(speed));

        if (shouldAttack)
            _animator.SetTrigger(Params.Attack);
    }
}
