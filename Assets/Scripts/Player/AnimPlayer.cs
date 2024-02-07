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
        public static readonly int IsGrounded = Animator.StringToHash(nameof(IsGrounded));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        public static readonly int Idle = Animator.StringToHash(nameof(Idle));
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        SetupAnimation(_movement.Speed, _movement.IsGrounded, _attack.ShouldAttack);
    }

    private void SetupAnimation(float speed, bool isGrounded, bool shouldAttack)
    {
        _animator.SetFloat(Params.Speed, speed);
        _animator.SetBool(Params.IsGrounded, isGrounded);

        if (shouldAttack)
            _animator.SetTrigger(Params.Attack);
    }
}
