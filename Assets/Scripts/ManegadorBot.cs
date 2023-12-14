using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class ManegadorBot : MonoBehaviour
{

    private Temporizador temporizador;
    SplineAnimate splineAnimate;

    // Start is called before the first frame update
    void Start()
    {
        temporizador = GetComponentInParent<Temporizador>(); 
        splineAnimate = GetComponentInParent<SplineAnimate>();
    }

    // Update is called once per frame
    void Update()
    {
        if (temporizador.tempo) {
            splineAnimate.Play();
        }
    }
}
