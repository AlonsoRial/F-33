using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationNave : MonoBehaviour
{

    Animator animator;
    static Mover mover;


    void Start()
    {
        animator = GetComponent<Animator>();
        mover = GetComponentInParent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
 
        if (mover.inputVector.x>0f && mover.corriendo )
        {
            animator.SetBool("VuD", false);
            animator.SetBool("GiD",true);
        }
        else if (  mover.inputVector.x <1f && mover.corriendo) 
        {
            animator.SetBool("GiD", false);
            animator.SetBool("VuD", true);
        }
        else
        {
            animator.SetBool("GiD", false);
            animator.SetBool("VuD", false);
        }

        // if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
        //  transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        // }

        if (!animator.GetBool("GiD") && !animator.GetBool("VuD")) 
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

    }


}
