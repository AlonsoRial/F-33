using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class ManegadorBot : MonoBehaviour
{

    private Temporizador temporizador;
    SplineAnimate splineAnimate;

    private BoxCollider box;

    public ParticleSystem lanza;
    public ParticleSystem lanza2;
    public ParticleSystem lanza3;

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

            SceneManager.LoadSceneAsync(4);
            Debug.Log(this.gameObject.name + " YYYYYYY");
            box.isTrigger = false;
            



        }
    }



    // Update is called once per frame
    void Update()
    {
        lanza.Stop();
        lanza2.Stop();
        lanza3.Stop();

        if (temporizador.tempo) {
            lanza.Play();
            lanza2.Play();
            lanza3.Play();
            splineAnimate.Play();
            box.isTrigger = true;
        }
    }
}
