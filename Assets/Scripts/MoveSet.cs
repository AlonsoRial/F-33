using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSet : MonoBehaviour
{

    [Header("Rotación")]
    public float velocidadRotacion;
    public float velocidadSpeed;

    public float _hInput;
    public float _vInput;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        _hInput = Input.GetAxis("Horizontal") * velocidadRotacion;


        //_vInput = Input.GetAxis("Vertical") * velocidadSpeed;
        _vInput = Input.GetAxis("Fire1")* velocidadSpeed;
        


        this.transform.Rotate(Vector3.up * _hInput* Time.deltaTime);

        

        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);

    }
}
