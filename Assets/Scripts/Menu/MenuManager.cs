using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager
{
    public static void GoToMenu(MenuName menu) 
    {
        switch (menu) 
        {
            case MenuName.Main:
                // Switch to Main Menu scene
                SceneManager.LoadScene("MainMenu");
            break;

            case MenuName.Pause:
                // Instantiate Pause Menu
                Object.Instantiate(Resources.Load("PauseMenu"));
            break;
        }
    }
}
