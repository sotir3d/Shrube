using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Surface")
            GetComponentInParent<PlayerMovement>().canJump = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Surface")
            GetComponentInParent<PlayerMovement>().canJump = false;
    }
}
