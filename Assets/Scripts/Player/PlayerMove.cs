using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour 
{
    [SerializeField] private Animator anim;
    [SerializeField] private float speed = 10f;

	// Use this for initialization
	void Start () 
    {
        anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float moveRight = Input.GetAxis("Horizontal");
        float moveForward = Input.GetAxis("Vertical");

        transform.Translate(moveRight * speed * Time.deltaTime, 0f, moveForward * speed * Time.deltaTime);

        Move(moveForward, moveRight);
    }

    void Move(float moveForward, float moveRight)
    {
        // Walking Movement
        if (moveForward > 0 && moveRight == 0)
        {
            anim.SetBool("isStrafing", false);
            anim.SetBool("isStrafingLeft", false);
            anim.SetBool("isWalkingBackward", false);
            anim.SetBool("isWalking", true);
        }
        else if (moveForward < 0 && moveRight == 0)
        {
            anim.SetBool("isStrafing", false);
            anim.SetBool("isStrafingLeft", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBackward", true);
        }

        // Strafing Movement
        else if (moveRight > 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBackward", false);
            anim.SetBool("isStrafingLeft", false);
            anim.SetBool("isStrafing", true);
        }
        else if (moveRight < 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBackward", false);
            anim.SetBool("isStrafing", false);
            anim.SetBool("isStrafingLeft", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isWalkingBackward", false);
            anim.SetBool("isStrafing", false);
            anim.SetBool("isStrafingLeft", false);
        }

        if (Input.GetAxis("Jump") > 0)
            anim.SetBool("isJumping", true);
        else
            anim.SetBool("isJumping", false);
    }
}
