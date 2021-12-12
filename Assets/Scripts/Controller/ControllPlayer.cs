using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllPlayer : MonoBehaviour
{
    public float maxSpeed = 10f;

    private bool isFacingRight = true;
    private Animator anim;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        anim = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float move = Input.GetAxisRaw("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));
        _rigidbody.velocity = new Vector2(move * maxSpeed, _rigidbody.velocity.y);

        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
