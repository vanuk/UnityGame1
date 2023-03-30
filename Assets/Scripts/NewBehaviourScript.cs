using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    private float horizontal1;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private KeyCode _leftKey = KeyCode.A;
    [SerializeField] private KeyCode _rightKey = KeyCode.D;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _jumpForce = 12f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Animator _animator;
    private Vector2 _movement;
    private bool _isGrounded;
    private bool _isFacingRight = true;
    private float _horizontalInput;

    [SerializeField] private Button jump;


 

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            
            _animator.SetBool("jump", true);
        }
        else if (!Input.GetButtonDown("Jump"))
        {
            _animator.SetBool("jump", false);
        }

        if (Input.GetButtonUp("Jump") && _rigidbody2D.velocity.y > 0f)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.5f);
            
        }
        
        
        
    }

    private void FixedUpdate()
    {
        float horizontal = _joystick.Horizontal;
        float vertical = _joystick.Vertical;
       
        // Зчитування введення з кнопок
        if (Input.GetKey(_leftKey)) horizontal = -1f;
        if (Input.GetKey(_rightKey)) horizontal = 1f;
        _movement = new Vector2(horizontal * _speed, _rigidbody2D.velocity.y);

        // Відтворення анімацій
        if (horizontal != 0f)
        {
            _animator.SetBool("run", true);
            if (_isFacingRight && horizontal < 0f || !_isFacingRight && horizontal > 0f)
            {
                Flip();
            }
        }
        if (horizontal == 0f)
        {
            _animator.SetBool("run", false);
        }

      
        _rigidbody2D.velocity = _movement;

        if (_isFacingRight && _movement.x < 0f || !_isFacingRight && _movement.x > 0f)
        {
            Flip();
        }
    }

    public void Jump()
    {
       
        
        if ( IsGrounded())
        {
            _rigidbody2D.velocity=new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            _animator.SetBool("jump",true);
        }
        else
        {
            _animator.SetBool("jump",false);
        }

        if (jump && _rigidbody2D.velocity.y > 0f)
       {
        //    _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _rigidbody2D.velocity.y * 0.5f);
       }
    }
 
  
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}