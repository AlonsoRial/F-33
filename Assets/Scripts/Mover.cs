using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{


    [SerializeField]
    private float rotationSpeed = 10f;

    [SerializeField]
    private float maxMoveSpeed = 15f;

    [SerializeField]
    private float maxMoveSpeedBack = 5f;

    [SerializeField]
    float speed = 0f;

    [SerializeField]
    float acceleration = 0.6f;

    [SerializeField]
    private int playerIndex = 0;

    Rigidbody rb;

    public Image speedBar;

    //private Vector3 moveDirection = Vector3.zero;

    private Vector2 inputVector = Vector2.zero;

    bool corriendo, retroceder;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
        
    }



    public int GetPlayerIndex()
    {
        return playerIndex;
    }

    public void SetInputVector(Vector2 direction)
    {
        inputVector = direction;
    }

    public void SetInputRun(bool IsRunnin)
    {
        if (IsRunnin == true)
        {
            corriendo = true;
        }
        else
        {
            corriendo = false;
        }

        Debug.Log("Mover : "+corriendo);
    }

    public void SetInputBack(bool IsRunnin)
    {
        if (IsRunnin == true)
        {
            retroceder = true;
        }
        else
        {
            retroceder = false;
        }

        Debug.Log("Mover : " + corriendo);
    }


    void Update()
    {

      
        /*
        float rotationAmount = inputVector.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
        */

        if (speed != 0)
        {
            this.transform.Rotate(Vector3.up * speed * inputVector.x * Time.deltaTime * rotationSpeed);
        }

        if (corriendo == true || InputManager.instance.playerControls.PlayerMovement.RumbleAction.WasPressedThisFrame())
        {
            RumbleManager.instance.RumblePulse(0.25f,1f,0.25f);

            if (speed < maxMoveSpeed)
            {
                speed += acceleration * Time.deltaTime;
                
            }

            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            //transform.position.x = transform.position.x + speed * Time.deltaTime;

            //this.transform.Translate(Vector3.forward * maxMoveSpeed * Time.deltaTime);
        }
        else {
            if (speed >= 0)
            {
                speed -= 3* acceleration * Time.deltaTime;
                this.transform.Translate(Vector3.forward * speed * Time.deltaTime );
            }
        }

        if (retroceder == true)
        {
            this.transform.Translate(-Vector3.forward * maxMoveSpeedBack * Time.deltaTime);
            this.transform.Rotate(Vector3.up * maxMoveSpeedBack * inputVector.x * Time.deltaTime * rotationSpeed);
        }

        try {
            speedBar.fillAmount = speed / maxMoveSpeed;
        }
        catch (NullReferenceException) {
        
        }
        

    }


}
