using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class MoveSetV2 : MonoBehaviour
{
    public PlayerInput _playerInput;
    public float velocidadRotacion;
    Vector2 movementInput;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = _playerInput.actions["Move"].ReadValue<Vector2>();

        this.transform.Rotate(Vector3.up * movementInput * Time.deltaTime * velocidadRotacion);

        if (_playerInput.actions["Run"].IsPressed()) {
            this.transform.Translate(Vector3.forward * velocidadRotacion * Time.deltaTime);
        }

    }
}
