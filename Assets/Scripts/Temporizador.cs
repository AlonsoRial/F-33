using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Splines;

public class Temporizador : MonoBehaviour
{
    [SerializeField] GameObject gameObjectTempo;
    [SerializeField] TextMeshProUGUI textoTempo;

    int temporazidor = 4;
    float tiempo = 4;

    public bool tempo = false;

    void Start()
    {
        
        gameObjectTempo.SetActive(true);
    }

    
    void Update()
    {
        if (temporazidor != 0)
        {
            tiempo -= Time.deltaTime;
            temporazidor = Mathf.FloorToInt(tiempo % 60);
            textoTempo.text = string.Format("{0:0}", temporazidor);
        }
        else {
            tempo = true;
            gameObjectTempo.SetActive(false);
        }


        

        

    }
}
