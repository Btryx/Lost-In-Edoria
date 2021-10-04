using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        GameObject[] objs = GameObject.FindGameObjectsWithTag("menu");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
