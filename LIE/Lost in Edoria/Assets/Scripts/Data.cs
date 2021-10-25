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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        GameObject[] objs = GameObject.FindGameObjectsWithTag("canvas");
        currentLevel = Player.Instance.TouchedFinishLine + 1;

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
