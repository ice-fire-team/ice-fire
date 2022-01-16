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
    void Start()
    {
        boton[0].onClick.AddListener(jugar);
        boton[1].onClick.AddListener(salir);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape") || Input.GetKey(KeyCode.S))
            salir();
        if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.J))
            jugar();

    }

    void salir()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void jugar()
    {
        SceneManager.LoadScene("FirstLevel");
    }
}