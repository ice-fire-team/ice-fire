using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Slider slider;

    AudioSource AS;

    float MAX_VOL=0.5f;

    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(updateVolume);
        slider.value=0.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void updateVolume(float s)
    {
        AS.volume = MAX_VOL*s*s;
    }



}
