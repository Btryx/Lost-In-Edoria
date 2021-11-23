using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public static Data Instance;
    public int currentLevel = 0;
    public int TouchedFinishLine;

    public float scoreholder;
    public float score;
    public float timer;
    public float timeHolder;
    public float timerscore;
    public float volume;
    public bool isFullscreen;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        currentLevel = TouchedFinishLine + 1;

        DontDestroyOnLoad(this.gameObject);

        if(SceneManager.GetActiveScene().buildIndex == 0) 
        { 
            scoreholder = 0;
            score = 0;
        }

    }

    
}
