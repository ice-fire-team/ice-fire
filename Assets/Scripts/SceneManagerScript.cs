using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SceneManagerScript : MonoBehaviour
{   
    [SerializeField]
    GameObject Kai, Kori;
    KaiKoriController KaiController, KoriController;
    [SerializeField]
    CinemachineFreeLook KaiCam, KoriCam;
    bool KaiKori;

    // Start is called before the first frame update
    void Start()
    {
        KaiKori = true;
        KaiController = Kai.GetComponent<KaiKoriController>();
        KoriController = Kori.GetComponent<KaiKoriController>();
        KaiController.animacion = Kai.GetComponent<Animator>();
        KoriController.animacion = Kori.GetComponent<Animator>();

    }

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){ToogleKaiKori();}
    }


    void ToogleKaiKori()
    {
        KaiKori = !KaiKori;
        int index = KaiKori ? 1 : 0;
        KaiController.activePlayer = KaiKori;
        KoriController.activePlayer = !KaiKori;
        KaiCam.m_Priority = index;
        KoriCam.m_Priority = 1 - index;
    }
}
