using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    public float distancia = 7.5f;
    LayerMask mask;
    private Transform transform;
    int Kai_Kori;
    public GameObject DetTexto,texto_palanca;
    GameObject Kai, Kori, Camera, palanca;
    GameObject ultimoReconocido = null;
    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("LayerDet");
        DetTexto.SetActive(false);
        texto_palanca.SetActive(false);
        Kai_Kori = 0;
        Kai = GameObject.Find("Kai");
        Kori = GameObject.Find("Kori");
        //Camera = GameObject.Find("MainCamera");
        palanca = GameObject.Find("lever");
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
        Vector3 vector = new Vector3(0f, 2.5f, 0.5f);
        if (Physics.Raycast(transform.position + vector, transform.TransformDirection(Vector3.forward) *distancia, out hit, distancia, mask)||
            Physics.Raycast(transform.position + vector, transform.TransformDirection(0.5f, 0f, 1f) * distancia, out hit, distancia, mask)||
            Physics.Raycast(transform.position + vector, transform.TransformDirection(-0.5f, 0f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + vector, transform.TransformDirection(-0.5f, 0.5f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + vector, transform.TransformDirection(0.5f, 0.5f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + vector, transform.TransformDirection(-0.5f, -0.5f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + vector, transform.TransformDirection(0.5f, -0.5f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + vector, transform.TransformDirection(0f, 0.5f, 1f) * distancia, out hit, distancia, mask) ||
            Physics.Raycast(transform.position + vector, transform.TransformDirection(0f, -0.5f, 1f) * distancia, out hit, distancia, mask))
        {
            
            Deselect();
            SelectedObject(hit);
            if (hit.collider.tag == "Boton")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameObject boton = GameObject.Find("boton1");
                    boton.GetComponent<Animator>().SetTrigger("Pulsado");
                    boton.GetComponent<AudioSource>().Play();
                    palanca.GetComponent<Palanca>().Pulsar_boton();
                    
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
        Debug.DrawRay(transform.position + vector, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        Debug.DrawRay(transform.position + vector, transform.TransformDirection(0.5f , 0f, 1f) * distancia, Color.red);
        Debug.DrawRay(transform.position + vector, transform.TransformDirection(-0.5f, 0f, 1f) * distancia, Color.red);
        Debug.DrawRay(transform.position + vector, transform.TransformDirection(0.5f, 0.5f, 1f) * distancia, Color.red);
        Debug.DrawRay(transform.position + vector, transform.TransformDirection(-0.5f, 0.5f, 1f) * distancia, Color.red);
        Debug.DrawRay(transform.position + vector, transform.TransformDirection(0.5f, -0.5f, 1f) * distancia, Color.red);
        Debug.DrawRay(transform.position + vector, transform.TransformDirection(-0.5f, -0.5f, 1f) * distancia, Color.red);
        Debug.DrawRay(transform.position + vector, transform.TransformDirection(0f, 0.5f, 1f) * distancia, Color.red);
        Debug.DrawRay(transform.position + vector, transform.TransformDirection(0f, -0.5f, 1f) * distancia, Color.red);

    }
    void SelectedObject(RaycastHit hit)
    {
        hit.transform.GetComponent<MeshRenderer>().material.color = Color.green;

        ultimoReconocido = hit.transform.gameObject;
    }
    void Deselect()
    {
        if(ultimoReconocido)
        {
            ultimoReconocido.GetComponent<MeshRenderer>().material.color = Color.white;
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
           texto_palanca.SetActive(false);
        }
    }
}
