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
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0 && SceneManager.GetActiveScene().buildIndex != 6) {
            if (Input.GetKeyDown(KeyCode.Escape) && !Question.Instance.gameObject.activeSelf)
            {
                QuestionSetActive();
                Debug.Log("escape");
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && Question.Instance.gameObject.activeSelf)
            {
                Cancel();
                Debug.Log("cancel");
            }
        }
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
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
        Time.timeScale = 0;
        Debug.Log("fuggveny");
    }

    public void Cancel()
    {
        Question.Instance.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
