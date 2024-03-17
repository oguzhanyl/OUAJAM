using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BarrelDestroy : MonoBehaviour
{
    [SerializeField] GameObject potPrefab;

    GameObject triggeredBarrel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void BarrelAttackPotDrop()
    {
        if(triggeredBarrel == null)
        {
            return;
        }
        int random = Random.Range(0, 11);
        Debug.Log("random num" + random);
        if (random <= 5)
        {
            Instantiate(potPrefab, triggeredBarrel.transform.position, Quaternion.identity);
        }

        Destroy(triggeredBarrel);
    }

    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Barrel")
        {
            Debug.Log("Barrel oldu");
            triggeredBarrel = collision.gameObject;
        }
    }

}
