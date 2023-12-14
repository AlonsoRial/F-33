using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationNave : MonoBehaviour
{

    Animator animator;
    static Mover mover;
    Vector2 previousInputVector = Vector2.zero;

    private Temporizador temporizador;

    private void Start()
    {
        animator = GetComponent<Animator>();
        mover = GetComponentInParent<Mover>();
        temporizador = GetComponentInParent<Temporizador>();

    }

    // Update is called once per frame
    void Update()
    {

        if (mover.corriendo && temporizador.tempo==true)
        {
            /*
            if (mover.inputVector.x > 0.0f)
            {
                animator.SetBool("VuD", false);
                animator.SetBool("GiD", true);
            }
            else if (mover.inputVector.x < 1.0f )
            {
                animator.SetBool("GiD", false);
                animator.SetBool("VuD", true);
            }
            else
            {
                animator.SetBool("GiD", false);
                animator.SetBool("VuD", false);

              //  animator.SetBool("GiI", false);
              //  animator.SetBool("VuI", false);
            }
        }


       if (!animator.GetBool("GiD") && !animator.GetBool("VuD") && !animator.GetBool("GiI") && !animator.GetBool("VuI") ) 
       {
           transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
       }
       */

            //Debug.Log(mover.inputVector.x);

            if (previousInputVector.x == 0 && mover.inputVector.x > 0)
            {

                Debug.Log("De 0 a 1");
                animator.SetBool("GiroD", true);
                animator.SetBool("VueltaD", false);

            }
            else if (previousInputVector.x > 0 && mover.inputVector.x == 0)
            {
                Debug.Log("De 1 a 0");

                animator.SetBool("VueltaD", true);
                animator.SetBool("GiroD", false);

            }
            else if (previousInputVector.x == 0 && mover.inputVector.x < 0)
            {
                Debug.Log("De 0 a -1");
                animator.SetBool("GiroI", true);
                animator.SetBool("VueltaI", false);
            }
            else if (previousInputVector.x < 0 && mover.inputVector.x == 0)
            {
                Debug.Log("De -1 a 0");
                animator.SetBool("VueltaI", true);
                animator.SetBool("GiroI", false);
            }
            else if (previousInputVector.x == 0 && mover.inputVector.x == 0)
            {


                // Debug.Log("Quieto");

            }

            previousInputVector.x = mover.inputVector.x;

            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

            }
        }

    }


}
