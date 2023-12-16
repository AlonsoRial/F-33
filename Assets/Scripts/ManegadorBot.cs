using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ManegadorBot : MonoBehaviour
{

    private Temporizador temporizador;
    SplineAnimate splineAnimate;

    private BoxCollider box;

    public bool meta=false;
    // Start is called before the first frame update
    void Start()
    {
        temporizador = GetComponentInParent<Temporizador>(); 
        splineAnimate = GetComponentInParent<SplineAnimate>();
        box = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "CheckPoint")
        {
            Debug.Log(this.gameObject.name + " PASO");
            meta = true;


        }


        if (other.name == "Final" && meta)
        {

          
            Debug.Log(this.gameObject.name + " YYYYYYY");
            box.isTrigger = false;
       



        }
    }



    // Update is called once per frame
    void Update()
    {
        if (temporizador.tempo) {
            splineAnimate.Play();
            box.isTrigger = true;
        }
    }
}
