using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Mover : MonoBehaviour
{


    public Camera camera1;
    public Camera camera2;

    public bool boolCamera;

    public ParticleSystem lanza;
    public ParticleSystem lanza2;
    public ParticleSystem lanza3;

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

    public bool  chocar;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
      

    }



    private void Start()
    {


        lanza.Stop();
        lanza2.Stop();
        lanza3.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Muro")
        {
            chocar = true;
            Debug.Log("CHOCANDO ");
        }

        if (collision.collider.tag == "Suelo")
        {

            if ((transform.eulerAngles.x >= 80 && transform.eulerAngles.x <= 180) || (transform.eulerAngles.z >= 80 && transform.eulerAngles.z <= 180))
            {
                Debug.Log("SUELO");

                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }

            if ((transform.eulerAngles.x >= -80 && transform.eulerAngles.x <= -180) || (transform.eulerAngles.z >= -80 && transform.eulerAngles.z <= -180))
            {
                Debug.Log("SUELO");

                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }

        }

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


    }



    public void SetCamera(bool atras)
    {
        boolCamera = atras;
    }



    void Update()
    {
        
        if (boolCamera)
        {
            camera2.enabled = true;
            camera1.enabled = false;
        }
        else
        {
            camera2.enabled = false;
            camera1.enabled = true;
        }


        if (chocar)
        {
            speed = speed / 2.7f;
            chocar=false;
        }


        /*
        float rotationAmount = inputVector.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
        */

        if (speed != 0)
        {
            this.transform.Rotate(Vector3.up * speed * inputVector.x * Time.deltaTime * rotationSpeed);
        }

        if (corriendo == true  /*&& chocar==false|| InputManager.instance.playerControls.PlayerMovement.RumbleAction.WasPressedThisFrame()*/)
        {

            lanza.Play();
            lanza2.Play();
            lanza3.Play();

            if (speed < maxMoveSpeed)
            {
                speed += acceleration * Time.deltaTime;

            }

            this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

            //transform.position.x = transform.position.x + speed * Time.deltaTime;

            //this.transform.Translate(Vector3.forward * maxMoveSpeed * Time.deltaTime);
        }
        else
        {
            lanza.Stop();
            lanza2.Stop();
            lanza3.Stop();
            if (speed >= 0)
            {
                speed -= 3 * acceleration * Time.deltaTime;
                this.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }

        if (retroceder == true)
        {
            
            this.transform.Translate(-Vector3.forward * maxMoveSpeedBack * Time.deltaTime);
            this.transform.Rotate(Vector3.up * maxMoveSpeedBack * inputVector.x * Time.deltaTime * rotationSpeed);
        }

        try
        {
            speedBar.fillAmount = speed / maxMoveSpeed;
        }
        catch (NullReferenceException)
        {

        }

        


    }


}
