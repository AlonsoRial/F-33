using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 5f;

    [SerializeField]
    private float MoveSpeed = 3f;

    [SerializeField]
    private int playerIndex = 0;

    private CharacterController controller;

    [SerializeField]
    private float gravityValue = -9.81f;

    private Vector3 moveDirection = Vector3.zero;
    private Vector3 moveRun = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;

    bool corriendo;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
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
        
    }


    void Update()
    {

        float rotationAmount = inputVector.x * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotationAmount);

       




    }


    private void FixedUpdate()
    {
        moveDirection.y += gravityValue * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);

        
    }

}
