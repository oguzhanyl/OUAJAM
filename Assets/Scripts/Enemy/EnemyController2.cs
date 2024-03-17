using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController2 : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Transform currentPoint;
    public float speed2;
    [SerializeField]Slider hpSlider2;
    float hpValue2;
    [SerializeField]private float damage;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody= GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        _animator.SetBool("isWalking", true);

    }
    private void Update()
    {




        hpValue2 = hpSlider2.value;

        if (hpValue2 <= hpSlider2.minValue)
        {
            _animator.SetTrigger("Start");
        }
        else
        {
            MovementBetweenAandB();
        }

    }

    private void MovementBetweenAandB()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            _rigidbody.velocity = new Vector2(speed2, 0);
        }
        else
        {
            _rigidbody.velocity = new Vector2(-speed2, 0);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInChildren<Slider>().value -= damage;
        }
    }

    private void DieFunction()
    {
        
        Destroy(gameObject.transform.parent.gameObject);
    }
    private void flip()
    { 
        Vector3 localScale=transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

}
