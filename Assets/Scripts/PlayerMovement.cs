using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canJump;

    enum JumpState
    {
        startJumping,
        jumping,
        falling
    };

    JumpState jumpState = JumpState.falling;

    Rigidbody2D rb;

    SpriteRenderer spriteRenderer;

    float speed = 10;

    float jumpForce;
    float maxJumpForce = 200;
    float jumpForceDecrease = 20;

    Vector2 newPosition;

    Quaternion newRotation;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        newPosition = transform.position;
        //jumpForce = maxJumpForce;

        newRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.GetAxis("Horizontal") * speed);
        

        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        //newPosition = transform.position;
        //newPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        //transform.position = newPosition;


        if (Input.GetAxis("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }


        if(canJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("start");
                jumpForce = maxJumpForce;
                jumpState = JumpState.startJumping;
                rb.velocity = new Vector2(0, 0);
            }
        }

        if (Input.GetButton("Jump"))
        {
            jumpState = JumpState.jumping;
        }

        if (Input.GetButtonUp("Jump"))
        {
            jumpForce = 0;
        }
        
    }

    private void FixedUpdate()
    {
        switch (jumpState)
        {
            case JumpState.jumping:
                rb.AddForce(new Vector2(0f, jumpForce));
                jumpForce -= jumpForceDecrease; //or whatever amount

                if (jumpForce < 0f)
                    jumpForce = 0f;
                break;
        }
    }

    //private void LateUpdate()
    //{
    //    Vector3 position = transform.localPosition;

    //    position.x = (Mathf.Round(transform.parent.position.x * PPU) / PPU) - transform.parent.position.x;
    //    position.y = (Mathf.Round(transform.parent.position.y * PPU) / PPU) - transform.parent.position.y;

    //    transform.localPosition = position;
    //}
}
