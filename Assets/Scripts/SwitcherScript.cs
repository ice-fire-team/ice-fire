using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FirstLevel");
    }
}
