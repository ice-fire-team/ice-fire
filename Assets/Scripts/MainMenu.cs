using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    Button[] boton;
    [SerializeField]
    Button[] botonNiv;
    [SerializeField]
    Button[] botonSalir;
    [SerializeField]
    GameObject canvasP, canvasN, canvasSalir, texto;
    void Start()
    {
        boton[0].onClick.AddListener(jugar);
        boton[1].onClick.AddListener(salir);
        botonNiv[0].onClick.AddListener(nivel1);
        botonNiv[1].onClick.AddListener(nivel2);
        botonNiv[2].onClick.AddListener(nivel3);
        botonNiv[3].onClick.AddListener(atras);
        botonSalir[0].onClick.AddListener(si);
        botonSalir[1].onClick.AddListener(no);
        canvasN.SetActive(false);
        canvasSalir.SetActive(false);
        texto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void salir()
    {
        canvasSalir.SetActive(true);
        canvasP.SetActive(false);
        texto.SetActive(false);
    }
    void si()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    void no()
    {
        canvasSalir.SetActive(false);
        canvasP.SetActive(true);
        texto.SetActive(false);
    }
    void jugar()
    {
        canvasP.SetActive(false);
        canvasN.SetActive(true);
        texto.SetActive(false);
    }

    void nivel1()
    {
        SceneManager.LoadScene("FirstLevel"); texto.SetActive(false);
    }
    void nivel2()
    {
        SceneManager.LoadScene("SecondLevel"); texto.SetActive(false);
    }
    void nivel3()

    {
        canvasN.SetActive(true);
        texto.SetActive(true);
    }
    void atras()
    {
        canvasN.SetActive(false);
        canvasP.SetActive(true);
        texto.SetActive(false);
    }
}
