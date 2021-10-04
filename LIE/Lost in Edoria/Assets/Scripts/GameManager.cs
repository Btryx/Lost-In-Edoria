using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int level = 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        GameObject[] objs = GameObject.FindGameObjectsWithTag("gameman");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(level);
    }
    public void Death()
    {
        StartCoroutine(ExecuteAfterTime(1));
    }
}

