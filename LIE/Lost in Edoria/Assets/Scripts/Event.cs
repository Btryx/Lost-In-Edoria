using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{

    public static Event Instance;
    public Scene currentscene;

    private void Awake()
    {   
        currentscene = SceneManager.GetActiveScene();

        if (Instance == null)
        {
            Instance = this;
        }

        GameObject[] objs = GameObject.FindGameObjectsWithTag("event");
        string SceneName = currentscene.name;

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        if (SceneName != "MainMenu" && SceneName != "Finished Game") DontDestroyOnLoad(this.gameObject);
    }
}
