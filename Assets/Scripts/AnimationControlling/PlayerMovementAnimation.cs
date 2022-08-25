using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    public Animator animator;

	void Start()
    {
        animator.Play("Silent Idle");
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
		{
            animator.Play("Walking Forward");
        }

        /*
        if (Input.GetKey(KeyCode.A))
        {
            animator.Play("Left Strafe Walking");
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.Play("Left Strafe Walking");
        }
        */

        if (Input.GetKey(KeyCode.S))
        {
            animator.Play("Walking Backwards");
        }

        if(!Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
		{
            
        }
    }

    public void ResetAnim()
	{
        animator.enabled = false;
        animator.enabled = true;
	}
}
