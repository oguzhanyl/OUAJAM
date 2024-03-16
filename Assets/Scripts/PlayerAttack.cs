using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackForce = 0;
    public bool clicked = false;
    private Rigidbody2D rigid2d;
    private Animator _animator;

    [HideInInspector] public bool grounded;
    void Start()
    {
        rigid2d= GetComponent<Rigidbody2D>();
        _animator= GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("attack", attackForce);
    }

    private void FixedUpdate()
    {
        if (grounded= true && Input.GetKey(KeyCode.Mouse1))
        {
            attackForce = 1;                       
        }
        else
        {
            attackForce = 0;
           
        }
          /*  if (clicked == true && Input.GetKey(KeyCode.Mouse1))
            {

                clicked = false;
            }
        */
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
