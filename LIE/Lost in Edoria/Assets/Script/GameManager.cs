using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if(Player.Instance.life <= 0)
        {
            StartCoroutine(ExecuteAfterTime(1));
        }
    }
}
