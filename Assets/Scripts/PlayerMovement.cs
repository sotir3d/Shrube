using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool canJump;

    public GameObject noiseLight;

    enum JumpState
    {
        startJumping,
        jumping,
        falling
    };

    JumpState jumpState = JumpState.falling;

    Rigidbody2D rb;

    SpriteRenderer spriteRenderer;

    float speed = 8;

    float jumpForce;
    //float maxJumpForce = 135;
    //float jumpForceDecrease = 7;
    float maxJumpForce = 250;
    float jumpForceDecrease = 27;



    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetAxis("Horizontal") < 0)
        //{
        //    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        //    spriteRenderer.flipX = true;
        //}
        //else if (Input.GetAxis("Horizontal") > 0)
        //{
        //    rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        //    spriteRenderer.flipX = false;
        //}

        if (Input.GetAxis("Horizontal") != 0)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
            spriteRenderer.flipX = (Input.GetAxis("Horizontal") < 0 ? true : false);
        }


        if (canJump)
        {
            if (Input.GetButtonDown("Jump"))
            {
                GameObject jumpLight;
                jumpLight = Instantiate(noiseLight, transform.position, transform.rotation);

                jumpLight.GetComponent<LightScript>().maxRange = 25;

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
