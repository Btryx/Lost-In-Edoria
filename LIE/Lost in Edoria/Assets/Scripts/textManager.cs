using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class textManager : MonoBehaviour
{
    public TextMeshProUGUI Time;
    public TextMeshProUGUI ScoreDis;
    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex != 6 && SceneManager.GetActiveScene().buildIndex != 0)
        {
            Time.text = "Time: " + System.Math.Round(Data.Instance.timer, 2);
            ScoreDis.text = "Score: " + System.Math.Round(Data.Instance.scoreholder, 2);
        }
    }
}
