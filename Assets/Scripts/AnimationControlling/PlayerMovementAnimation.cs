using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    public Animator animator;

    public ThirdPersonMovement movement;

	void Start()
    {
        animator.Play("Silent Idle");
    }

    void Update()
    {
        if(!movement.isGrounded)
		{
            animator.Play("Walking Forward");
        } else
		{
            if(Input.GetKey(KeyCode.W))
		    {
                animator.Play("Walking Forward");
            }

            if (Input.GetKey(KeyCode.A))
            {
                animator.Play("Walking Forward");
            }

            if (Input.GetKey(KeyCode.S))
            {
                animator.Play("Walking Backwards");
            }

            if (Input.GetKey(KeyCode.D))
            {
                animator.Play("Walking Forward");
            }
		}

        
    }

    public void ResetAnim()
	{
        animator.enabled = false;
        animator.enabled = true;
	}
}
