using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(KeyCode.P) )
        {
            LoadFirstLevel();
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
            EditorApplication.ExitPlaymode();
        }
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("FirstLevel");
    }
}
