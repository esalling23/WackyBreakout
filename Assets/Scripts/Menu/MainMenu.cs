using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void HandlePlayButtonClick() 
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void HandleQuitButtonClick() 
    {
        Application.Quit();
    }
}
