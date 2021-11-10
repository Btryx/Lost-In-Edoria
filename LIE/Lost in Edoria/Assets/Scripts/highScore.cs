using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class highScore : MonoBehaviour
{
    public TextMeshProUGUI highest;
    public float endScore;
    private void Start()
    {
        highS();
        highest.text = PlayerPrefs.GetFloat("Highscore", 0).ToString();
    }

    public void highS()
    {
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            endScore = Data.Instance.scoreholder;
            if (endScore > PlayerPrefs.GetFloat("Highscore", 0))
            {
                PlayerPrefs.SetFloat("Highscore", endScore);
            }
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("Highscore");
        highest.text = "0";
    }
}