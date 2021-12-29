using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    public float distancia = 7.5f;
    LayerMask mask;
    private Transform transform;
    int Kai_Kori;
    public GameObject DetTexto;
    GameObject Kai, Kori, Camera;
    GameObject ultimoReconocido = null;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("LayerDet");
        DetTexto.SetActive(false);
        Kai_Kori = 0;
        Kai = GameObject.Find("Kai");
        Kori = GameObject.Find("Kori");
        //Camera = GameObject.Find("MainCamera");

        transform = Kai.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Kai_Kori == 0)
            {
                Kai_Kori = 1;

                transform = Kori.GetComponent<Transform>();

            }
            else
            {
                Kai_Kori = 0;

                transform = Kai.GetComponent<Transform>();
            }
        }
        if (Physics.Raycast(transform.position + Vector3.up * 1.5f, transform.TransformDirection(Vector3.forward) *distancia, out hit, distancia, mask)||
            Physics.Raycast(transform.position + Vector3.up * 1.5f, transform.TransformDirection(0.5f, 0f, 1f) * distancia, out hit, distancia, mask)||
            Physics.Raycast(transform.position + Vector3.up * 1.5f, transform.TransformDirection(-0.5f, 0f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + Vector3.up * 1.5f, transform.TransformDirection(-0.5f, 0.5f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + Vector3.up * 1.5f, transform.TransformDirection(0.5f, 0.5f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + Vector3.up * 1.5f, transform.TransformDirection(-0.5f, -0.5f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + Vector3.up * 1.5f, transform.TransformDirection(0.5f, -0.5f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + Vector3.up * 1.5f, transform.TransformDirection(0f, 0.5f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + Vector3.up * 1.5f, transform.TransformDirection(0f, -0.5f, 1f) * distancia, out hit, distancia, mask))
        {
            
            Deselect();
            SelectedObject(hit);
            if (hit.collider.tag == "Cableado")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject Palanca = GameObject.Find("boton1");
                    Palanca.GetComponent<Palanca>().Pulsar_boton();
                }
            }else if (hit.collider.tag == "Palanca")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<Palanca>().AbrirPuerta();

                }
            }

        }
        
        else
        {
            Deselect();
        }
        ;
        //Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        //Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.TransformDirection(0.5f , 0f, 1f) * distancia, Color.red);
        //Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.TransformDirection(-0.5f, 0f, 1f) * distancia, Color.red);
        //Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.TransformDirection(0.5f, 0.5f, 1f) * distancia, Color.red);
        //Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.TransformDirection(-0.5f, 0.5f, 1f) * distancia, Color.red);
        //Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.TransformDirection(0.5f, -0.5f, 1f) * distancia, Color.red);
        //Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.TransformDirection(-0.5f, -0.5f, 1f) * distancia, Color.red);
        //Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.TransformDirection(0f, 0.5f, 1f) * distancia, Color.red);
        //Debug.DrawRay(transform.position + Vector3.up * 1.5f, transform.TransformDirection(0f, -0.5f, 1f) * distancia, Color.red);

    }
    void SelectedObject(RaycastHit hit)
    {
        hit.transform.GetComponent<Renderer>().material.color = Color.green;
        ultimoReconocido = hit.transform.gameObject;
    }
    void Deselect()
    {
        if(ultimoReconocido)
        {
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }
    private void OnGUI()
    {

        if(ultimoReconocido)
        {
           DetTexto.SetActive(true);
        }else
        {
           DetTexto.SetActive(false);
        }
    }
}
