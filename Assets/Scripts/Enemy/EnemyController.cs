using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] Transform bulletSpawner;

    [SerializeField] private float loopTime;
    private Animator _animator;

    private GameObject player;


    [SerializeField] float range, movementRange;
    private float distance;
    [SerializeField] private float movementSpeed;
    bool fireBulletCalled;


    [SerializeField] Slider hpSlider;
    float hpValue;


    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        player = GameObject.FindWithTag("Player");
    }
    private void Update()
    {
        hpValue = hpSlider.value;

        if(hpValue <= hpSlider.minValue)
        {
            DieFunction();
        }


        EnemyMovement();

        EnemyLookatPlayer();
    }

    private void DieFunction()
    {
        _animator.SetTrigger("Start");
       
        
    }


    private void EnemyMovement()
    {
        distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        Debug.Log(distance);
        if (distance < range)
        {
            if (!fireBulletCalled)
            {
                fireBulletCalled = true;
                StartCoroutine(FireBullet());

            }
        }
        else if(distance<movementRange)
        {
            StopAllCoroutines();
            transform.Translate(-1*movementSpeed * Time.deltaTime, 0, 0);
            fireBulletCalled = false;
        }
        else
        {
            fireBulletCalled = false;
            StopAllCoroutines();
        }
    }

    private void EnemyLookatPlayer()
    {
        if (gameObject.transform.position.x - player.transform.position.x > 0)
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    IEnumerator FireBullet()
    {
        float randomRotate;
        while (fireBulletCalled)
        {

            yield return new WaitForSeconds(loopTime);


            randomRotate = Random.Range(-6, 6);
            Vector3 spawnerAngle = bulletSpawner.transform.eulerAngles;
            bulletSpawner.transform.eulerAngles = new Vector3(spawnerAngle.x, spawnerAngle.y, randomRotate);

            Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.Euler(bulletSpawner.eulerAngles));
        }

        StopCoroutine(FireBullet());
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, movementRange);
    }
}
