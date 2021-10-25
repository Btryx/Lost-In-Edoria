using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance;
    public Scene currentscene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        GameObject[] objs = GameObject.FindGameObjectsWithTag("canvas");
        currentscene = SceneManager.GetActiveScene();
        string SceneName = currentscene.name;

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        if (SceneName != "MainMenu" && SceneName != "Finished Game") DontDestroyOnLoad(this.gameObject);
    }
}
