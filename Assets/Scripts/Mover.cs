using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5f;

    [SerializeField]
    private float moveSpeed = 3f;

    [SerializeField]
    private int playerIndex = 0;

    Rigidbody rb;


    //private Vector3 moveDirection = Vector3.zero;

    private Vector2 inputVector = Vector2.zero;

    bool corriendo;

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


    void Update()
    {

        float rotationAmount = inputVector.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
        
        if (corriendo == true)
        {
            this.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

    }


}
