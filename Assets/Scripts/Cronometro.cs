using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textoCrono;
    [SerializeField] private float tiempo;

    private int minutos, segundos, decimas;

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
        Crono();
    }
}
