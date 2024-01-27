using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _coins;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement.Move(_speed);
        TurnAnimator();
        _movement.Jump(_jumpForce);
    }
    
    public void IncreaseCoins(int value)
    {
        _coins += value;
    }

    private void TurnAnimator()
    {
        _animator.SetBool("isRun", _movement.IsRun);
    }
}
