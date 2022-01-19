using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinalLevelManagerScript : MonoBehaviour
{
    [SerializeField]
    private FinalTrigger final_Kai, final_Kori;


    [SerializeField]
    private Transform respawnKai, respawnKori, respawnOldKai, respawnOldKori;

    [SerializeField]
    private GameObject Kai, Kori,canvas,camara;

    [SerializeField]
    Button[] boton;

    

    // Start is called before the first frame update
    void Start()
    {
        boton[0].onClick.AddListener(jugar);
        boton[1].onClick.AddListener(salir);
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(final_Kai.hasPlayer && final_Kori.hasPlayer)
        {
            // Cambiamos respawns antiguos
            respawnOldKai.transform.position = respawnKai.transform.position;
            respawnOldKori.transform.position = respawnKori.transform.position;

            // Cambiamos positions de los players
            Kai.transform.position = respawnOldKai.transform.position;
            Kori.transform.position = respawnOldKori.transform.position;
            // Desactivamos el hasPlayer
            final_Kai.hasPlayer = false;
            final_Kori.hasPlayer = false;
            canvas.SetActive(true);
            camara.GetComponent<AudioListener>().enabled = false;
            Time.timeScale = 0;
            // Destroy(this);

        }
        if(Input.GetKeyDown("2")){
            // Cambiamos respawns antiguos
            respawnOldKai.transform.position = respawnKai.transform.position;
            respawnOldKori.transform.position = respawnKori.transform.position;

            // Cambiamos positions de los players
            Kai.transform.position = respawnOldKai.transform.position;
            Kori.transform.position = respawnOldKori.transform.position;
            // Desactivamos el hasPlayer
            final_Kai.hasPlayer = false;
            final_Kori.hasPlayer = false;
        }
    }
    void jugar()
    {
        camara.GetComponent<AudioListener>().enabled = true;
        Time.timeScale = 1;
        canvas.SetActive(false);
    }
    void salir()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Splash");
    }
}
