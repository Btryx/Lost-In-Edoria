using UnityEngine;
using TMPro;

public class endScreenTextManager : MonoBehaviour
{
    public TextMeshProUGUI YourTime;
    public TextMeshProUGUI YourScore;

    private void Awake()
    {
        YourTime.text = System.Math.Round(Data.Instance.timeHolder, 2) + "\n seconds";
        YourScore.text = System.Math.Round(Data.Instance.scoreholder, 2) + "\n";   
    }
}
