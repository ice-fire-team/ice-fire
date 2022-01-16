using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelManagerScript : MonoBehaviour
{
    [SerializeField]
    private FinalTrigger final_Kai, final_Kori;


    [SerializeField]
    private Transform respawnKai, respawnKori, respawnOldKai, respawnOldKori;

    [SerializeField]
    private GameObject Kai, Kori;

    

    // Start is called before the first frame update
    void Start()
    {
        
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

            // Destroy(this);

        }
    }
}
