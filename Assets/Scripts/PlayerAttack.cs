using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float attackForce = 0;
    public bool clicked = false;
    private Rigidbody2D rigid2d;
    private Animator _animator;

    [HideInInspector] public bool grounded;

    List<GameObject> triggeredGO=new List<GameObject>();

    [SerializeField] float attackDamage;
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
        if (Input.GetKey(KeyCode.Mouse1))
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

    public void Attack()
    {
        foreach(GameObject go in triggeredGO)
        {
            Slider slider = go == null?null: go.GetComponentInChildren<Slider>();

            if(slider != null)
            {
                Debug.Log(slider.value);
                slider.value -= attackDamage;
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(collision.gameObject.name);
            triggeredGO.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            triggeredGO.Remove(collision.gameObject);
        }
    }
}
