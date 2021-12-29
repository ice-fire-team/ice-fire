using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour {
    //private Animator puerta;
    GameObject puertaK;
    private Transform puerta;
    public bool Open;
    public float Aopen = 95f;
    public float Aclose = 0f;
    private float vel = 3.0f;
    public bool Palanca_activada;
    //public AudioClip Apuerta;
    //public AudioClip Cpuerta;
    private void Start() {

        Open = false;
        Palanca_activada = false;
        puertaK = GameObject.Find("PuertaKori");
        puerta = puertaK.GetComponent<Transform>();
    }
    public void AbrirPuerta()
    {
        if(Palanca_activada) Open = true;
       
    }
    public void Pulsar_boton()
    {
        Palanca_activada = !Palanca_activada;

    }
    void Update()
    {
        if (Open)
        {
            Quaternion rot = Quaternion.Euler(0, Aopen, 0);
            puerta.localRotation = Quaternion.Slerp(puerta.localRotation, rot, vel * Time.deltaTime);

        }else
        {
            Quaternion rot2  = Quaternion.Euler(0, Aclose, 0);
            puerta.localRotation = Quaternion.Slerp(puerta.localRotation, rot2, vel * Time.deltaTime);
        }
    }


}
