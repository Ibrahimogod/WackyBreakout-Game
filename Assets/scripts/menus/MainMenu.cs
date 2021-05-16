using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandleStartButton()
    {
        SceneManager.LoadScene("gameplay");
    }

    public void HandleHelpButton()
    {
        Instantiate(Resources.Load(MenuName.HelpMenu.ToString()));
    }

    public void HandleQuitButton()
    {
        Application.Quit();
    }
}
