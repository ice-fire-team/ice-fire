using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boton2 : MonoBehaviour
{
    GameObject puertaK, boton2;
    private Transform puerta;
    public bool Open;
    public float Aopen = 95f;
    public float Aclose = 0f;
    private float vel = 3.0f;
    private void Start()
    {

        Open = false;
        puertaK = GameObject.Find("PuertaKai");
        boton2 = GameObject.Find("boton2");
        puerta = puertaK.GetComponent<Transform>();
    }
    public void AbrirPuerta()
    {
            Open = !Open;
    }
    void Update()
    {
        if (Open)
        {
            Quaternion rot = Quaternion.Euler(0, Aopen, 0);
            puerta.localRotation = Quaternion.Slerp(puerta.localRotation, rot, vel * Time.deltaTime);

        }
        else
        {
            Quaternion rot2 = Quaternion.Euler(0, Aclose, 0);
            puerta.localRotation = Quaternion.Slerp(puerta.localRotation, rot2, vel * Time.deltaTime);
        }
    }


}

