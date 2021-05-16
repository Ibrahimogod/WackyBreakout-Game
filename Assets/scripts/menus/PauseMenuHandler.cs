using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale >= 1)
        {
            Instantiate(Resources.Load(MenuName.PauseMenu.ToString()));
        }
    }
}
