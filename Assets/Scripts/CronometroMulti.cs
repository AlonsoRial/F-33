using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CronometroMulti : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textoCronoJ1;
    [SerializeField] private float tiempoJ1;

    [SerializeField] TextMeshProUGUI textoCronoJ2;
    [SerializeField] private float tiempoJ2;

    private int minutosJ1, segundosJ1, decimasJ1;

    private int minutosJ2, segundosJ2, decimasJ2;

    void Crono() {
        tiempoJ1 += Time.deltaTime;

        tiempoJ2 += Time.deltaTime;

        minutosJ1 = Mathf.FloorToInt(tiempoJ1 / 60);
        segundosJ1 = Mathf.FloorToInt(tiempoJ1 % 60);
        decimasJ1 = Mathf.FloorToInt((tiempoJ1%1)*100);



        minutosJ2 = Mathf.FloorToInt(tiempoJ2 / 60);
        segundosJ2 = Mathf.FloorToInt(tiempoJ2 % 60);
        decimasJ2 = Mathf.FloorToInt((tiempoJ2 % 1) * 100);

        textoCronoJ1.text = string.Format("{0:00}:{1:00}:{2:00}", minutosJ1,segundosJ1,decimasJ1);


        textoCronoJ2.text = string.Format("{0:00}:{1:00}:{2:00}", minutosJ2, segundosJ2, decimasJ2);
    }


    // Update is called once per frame f
    void Update()
    {
        Crono();
    }
}
