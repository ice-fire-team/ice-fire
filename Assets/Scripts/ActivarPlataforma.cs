using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarPlataforma : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject palanca, plataforma;
    private bool A_D = false;
    void Start()
    {
        A_D = false;
        plataforma.GetComponent<Animator>().speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activar()
    {
        if (!A_D)
        {
            A_D = !A_D;
            plataforma.GetComponent<Animator>().speed = 1;

        } 
        else 
        {
            plataforma.GetComponent<Animator>().speed = 0;
            A_D = !A_D;

        }

        palanca.GetComponent<Animator>().SetTrigger("Activado");
    }
}
