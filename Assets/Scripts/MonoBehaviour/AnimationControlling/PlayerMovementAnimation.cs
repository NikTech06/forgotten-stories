using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    public Animator animator;

	void Start()
    {
        //animator.Play("Silent Idle");
    }

    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.W))
		{
            animator.SetBool("W", true);
        } else
		{
            animator.SetBool("W", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("S", true);
        }
        else
        {
            animator.SetBool("S", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("A", true);
        }
        else
        {
            animator.SetBool("A", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("D", true);
        }
        else
        {
            animator.SetBool("D", false);
        }
    }

    public void ResetAnim()
	{
        animator.enabled = false;
        animator.enabled = true;
	}
}
