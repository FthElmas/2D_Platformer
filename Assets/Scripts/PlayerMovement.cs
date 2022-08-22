using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private float moveInput;
    [SerializeField] private float speed;
    private bool isGrounded;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float jumpForce;
    private Animator _animator;
    private bool Grounded;
    private Action Animations;
    private Action Movements;
    
    
     

    


    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        Animations += RunningAnimation;
        Movements += PlayerDirectionSwitch;
        Movements += PlayerJump;

       
       

    }

    private void Update()
    {
       float horizontal = Input.GetAxis("Horizontal");
    

        body.velocity = new Vector2(horizontal * speed , body.velocity.y);
        Animations();
        Movements();
        
       

       
        


    }

    void PlayerDirectionSwitch()//switches player's direction according to his movement
    {
        float horizontal = Input.GetAxis("Horizontal");
        if(horizontal > 0.01f)
        {
            transform.localScale = new Vector3(3,3,1);
            this.transform.rotation = Quaternion.AngleAxis(180,Vector3.up);
        }

        else if (horizontal < -0.01f)
            transform.localScale = new Vector2(-3,3);
            this.transform.rotation = Quaternion.AngleAxis(0,Vector3.up);

    }

    void PlayerJump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);//checks players position
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
            body.velocity = Vector2.up * jumpForce;
        }
        Grounded = false;
        _animator.SetBool("Grounded", isGrounded);
        
        
        
        

    }

    void RunningAnimation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _animator.SetBool("Run", horizontal !=0 );
    }
}