using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPlayer : MonoBehaviour
{
    [SerializeField]
    public float maxSpeed;

    private bool _isFacingRight = true;
    private Animator _anim;
    private Rigidbody2D _rigidbody;

    //Для метода прыжка
    [SerializeField]
    public float _jumpForce;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float move = Input.GetAxisRaw("Horizontal");

        _anim.SetFloat("Speed", Mathf.Abs(move));
        _rigidbody.velocity = new Vector2(move * maxSpeed, _rigidbody.velocity.y);

        if (move > 0 && !_isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && _isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void Jump()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            //_rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }

    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    private float GroundCheckRadius;

    private void CheckingGround()
    {

    }

}
