using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quitGame()
    {
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void QuestionSetActive()
    {
        Question.Instance.gameObject.SetActive(true);
    }

    public void Cancel()
    {
        Question.Instance.gameObject.SetActive(false);
    }

}
