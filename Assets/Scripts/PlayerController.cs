using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject gameobj;
    [SerializeField] public float speed = 0.0f;
    [SerializeField] private float jumpForce = 3f;
    private Rigidbody2D rigid2d;
    private Animator _animator;
    private Vector3 vct;

    
    [HideInInspector] public bool isJumping;
    private bool jumpButtonPressed;

   [HideInInspector] public bool grounded;
    private bool started;
    private bool jumping;

    [SerializeField] Slider hpSlider;
    float hpValue;

    [SerializeField] GameObject gameOverPanel;

    [SerializeField] float potionHpValue;

    void Start()
    {
        Time.timeScale = 1;

        rigid2d = GetComponent<Rigidbody2D>(); 
        _animator= GetComponent<Animator>();
       
        started = false;
        gameOverPanel.SetActive(false);
    }   
    void Update()
    {
        _animator.SetFloat("jump", jumpForce);
        _animator.SetFloat("speed",speed);
        _animator.SetBool("grounded",grounded);
      
       /* vct = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += vct * speed * Time.deltaTime;
        _animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        
        if (Input.GetAxisRaw("Horizontal")== -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

    else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        } */
         if (Input.GetKey("d"))
          {
              started = true;

          }
          if (Input.GetKey("a"))
          {
              started = true;

          }
          if (Input.GetKey("space")) { 
              started = true;                       
          }

        hpValue = hpSlider.value;

        if (hpValue <= hpSlider.minValue)
        {
            _animator.SetTrigger("death");
        }
    }
    private void FixedUpdate()
    {
       
        if (started && Input.GetKey("d")) 
        {
            speed= 1.3f;         
            rigid2d.velocity = new Vector2(speed, rigid2d.velocity.y);
            gameobj.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            started = false;
        }else 
        {
           speed = 0.0f;
        }
        if (started && Input.GetKey("a"))
        {
          speed= 1.3f;
            rigid2d.velocity = new Vector2(-speed, rigid2d.velocity.y);
            gameobj.transform.rotation = Quaternion.Euler(0f, 180f, 0f);  
            started = false;            
        }
        else 
        {
            
        }
        if(grounded==true && Input.GetKey("space"))
        {             
                jumpForce = 3.8f;
                rigid2d.velocity = new Vector2(0f, jumpForce);
                started = false;
                grounded = false;
                jumpForce= 0f;
        }   
        
    }

    public void deathFunction()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("UnityFirstSave");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Barrel"))
        {
            grounded = true;
        }
        if (collision.gameObject.CompareTag("Potion"))
        {
            hpSlider.value += potionHpValue;
            Destroy(collision.gameObject);
        }
    }
}
