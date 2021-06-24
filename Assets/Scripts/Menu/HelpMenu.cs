using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{

    public void HandleHelpBackButtonPress()
    {
        MenuManager.GoToMenu(MenuName.Main);
    }
}
