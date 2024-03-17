using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BarrelDestroy : MonoBehaviour
{
    public float potion;
    public int randomNum;
    GameObject _gmobj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="Barrel" && Input.GetKey(KeyCode.Mouse1))
        {
            Destroy(collision.gameObject);
            randomNum = Random.Range(1, 10 + 1);
            if(randomNum > 0 && randomNum < 6)  
            {
               
            }
        }
    }

}
