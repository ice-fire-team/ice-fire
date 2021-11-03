using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
     public Camera[] Cams;
     public int CamIndex;

     void Start(){
      
      CamIndex= 0;
      Cams[0].enabled = true;

      for(int i= 1; i< Cams.Length; i++){

         Cams[i].enabled = false;
      }


     }
     

    
   
    void Update()
    {

       if (Input.GetKeyDown(KeyCode.R))
       {
          Cams[CamIndex].enabled = false;
          if(++CamIndex > Cams.Length -1) CamIndex = 0;
          Cams[CamIndex].enabled =true;
       }
     
}
}


