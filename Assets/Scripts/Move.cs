using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public int MoveSpeed=0;
    public int MoveSpeedUp=0;

    public GameObject[] dialog;

    public bool isClimb=false;

    private float move;

  
    private bool isFase = true;


   // public GameObject player;

   // public GameObject fon;
   // public Camera c;
    public float jumpingPower = 16f;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

  
    


    public Animator anim;
    public Animator anim1;
    void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
     
    }

    // Update is called once per frame
    void Update()
    {   
      
        
       
     

    }

    void Flip()
    {
        if (isFase && move < 0f || !isFase && move > 0f)
        {
            isFase = !isFase;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

 
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);
    }

   
   

  

    

    public void FixedUpdate()
    {
        move = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * MoveSpeed;
       

        if (Input.GetKeyDown(KeyCode.F))
        {
            anim1.SetBool("1",true);
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

       
        Flip();
        if (isClimb == true)
        {
            
            var move1 = Input.GetAxis("Vertical");
            transform.position += new Vector3(0, move1, 0) * Time.deltaTime * MoveSpeedUp;
        }
        if (move > 0.0f||move < 0.0f)
        {
            anim.SetBool("run",true);
        }
        if(move==0.0f)
        {
            anim.SetBool("run",false);
        }
         
        
    }

    
    
}
