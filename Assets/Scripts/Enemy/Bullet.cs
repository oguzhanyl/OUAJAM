using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float destroyTime;
    private float time=0;

    [SerializeField] float damage;
    private void Update()
    {
        transform.Translate(speed*Time.deltaTime, 0, 0);

        time += Time.deltaTime;

        if(time >= destroyTime)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponentInChildren<Slider>().value -= damage;
            Destroy(gameObject);
        }
    }
}
