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
            case MenuName.PauseMenu:
                MonoBehaviour.Instantiate(Resources.Load(MenuName.HelpMenu.ToString()));
                break;
            case MenuName.LostMenu:
                SceneManager.LoadScene(MenuName.LostMenu.ToString());
                break;
            case MenuName.MainMenu:
                SceneManager.LoadScene(MenuName.MainMenu.ToString());
                break;
            case MenuName.HelpMenu:
                SceneManager.LoadScene(MenuName.HelpMenu.ToString());
                break;
        }
    }
}
