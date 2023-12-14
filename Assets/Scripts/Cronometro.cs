using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textoCrono;
    [SerializeField] private float tiempo;

    private int minutos, segundos, decimas;
  
    private Temporizador temporizador;

    private void Start()
    {
        temporizador = GetComponentInParent<Temporizador>();
    }
    void Crono() {
        tiempo += Time.deltaTime;

        minutos = Mathf.FloorToInt(tiempo / 60);
        segundos = Mathf.FloorToInt(tiempo % 60);
        decimas = Mathf.FloorToInt((tiempo%1)*100);

        textoCrono.text = string.Format("{0:00}:{1:00}:{2:00}", minutos,segundos,decimas);
    }


    // Update is called once per frame f
    void Update()
    {

        if (temporizador.tempo == true)
        {
            Crono();
        }
        
    }
}
