using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
            _animator.Play("Run");
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _spriteRenderer.flipX = true;
            _animator.Play("Run");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(0, _jumpForce * Time.deltaTime, 0);
            _animator.Play("Jump");
        }
    }
}
