using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSet : MonoBehaviour
{

    [Header("Rotación")]
    public float velocidadRotacion;
    public float maxAngleRotation = 15f;

    [Header("Movimiento")]
    public float velocidadSpeedVertical;
    public float velocidadSpeedHorizontal;

    [Header("Input")]
    public float horizontalInput;
    public float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
}
