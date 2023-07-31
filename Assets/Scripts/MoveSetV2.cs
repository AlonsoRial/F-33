using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class MoveSetV2 : MonoBehaviour
{
    public PlayerInput _playerInput;
    public float speedRotation = 30;
    public float speedRun=30;

    Vector2 movementInput;

    public float rotarSwitch;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //movementInput = _playerInput.actions["Move"].ReadValue<Vector2>();
        //this.transform.Rotate(Vector3.up * movementInput * Time.deltaTime * velocidadRotacion);


        rotarSwitch = _playerInput.actions["Move"].ReadValue<float>();

        this.transform.Rotate(Vector3.up * rotarSwitch * Time.deltaTime * speedRotation);

        if (_playerInput.actions["Run"].IsPressed()) {
            this.transform.Translate(Vector3.forward * speedRun * Time.deltaTime);
        }
        else if (_playerInput.actions["NoRun"].IsPressed())
        {
            Vector3 auxi = Vector3.forward * speedRun * Time.deltaTime;
            this.transform.Translate(-auxi);
        }

    }
}
