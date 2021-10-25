using UnityEngine;
using TMPro;

public class endScreenTextManager : MonoBehaviour
{
    public TextMeshProUGUI YourTime;
    public TextMeshProUGUI YourScore;

    private void Awake()
    {

        YourTime.text = Data.Instance.timeHolder + "";
        YourScore.text = Data.Instance.scoreholder + "";
        
        
    }
}
