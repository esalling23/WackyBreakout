using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    void Start() 
    {
        Time.timeScale = 0;
    }

    public void HandleResumePlayButtonClick() 
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandleQuitButtonClick() 
    {
        SceneManager.LoadScene("MainMenu");
    }
}
