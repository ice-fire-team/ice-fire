using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject canvasPausa, canvasOpciones, canvasSalir,camara;
    Slider slider;
    [SerializeField]
    Button[] boton;
    void Start()
    {
        canvasPausa.SetActive(false);
        canvasOpciones.SetActive(false);
        canvasSalir.SetActive(false);
        boton[0].onClick.AddListener(resume);
        boton[1].onClick.AddListener(opciones);
        boton[2].onClick.AddListener(salir);
        boton[3].onClick.AddListener(si);
        boton[4].onClick.AddListener(no);
        boton[5].onClick.AddListener(saliropciones);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape")){

            pausa();
        }
    }
    void resume()
    {
        camara.GetComponent<AudioListener>().enabled = true;
        Time.timeScale = 1;
        canvasPausa.SetActive(false);
    }
    void pausa()
    {
        camara.GetComponent<AudioListener>().enabled = false;
        Time.timeScale = 0;
        canvasPausa.SetActive(true);
    }
    void opciones()
    {
        canvasPausa.SetActive(false);
        canvasOpciones.SetActive(true);
    }
    void salir()
    {
        canvasPausa.SetActive(false);
        canvasSalir.SetActive(true);
    }
    void si()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Splash");
    }
    void no()
    {
        canvasSalir.SetActive(false);
        canvasPausa.SetActive(true);
    }
    void saliropciones()
    {
        canvasPausa.SetActive(true);
        canvasOpciones.SetActive(false);

    }
}
