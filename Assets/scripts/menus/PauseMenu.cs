using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 0;

    }

    public void HandleRestartButton()
    {
        SceneManager.LoadScene("gameplay");
    }

    public void HandleQuitButton()
    {
        Application.Quit();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
