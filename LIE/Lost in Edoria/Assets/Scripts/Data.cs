using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Data : MonoBehaviour
{
    public static Data Instance;
    public int currentLevel;
    public int highest;
    public float scoreholder;
    public int score;
    public float timer;
    public float timeHolder;
    public float timerscore;
    public float volume;
    public bool fs;
    public int resolution;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        currentLevel = Player.Instance.TouchedFinishLine + 1;

        DontDestroyOnLoad(this.gameObject);
    }
}
