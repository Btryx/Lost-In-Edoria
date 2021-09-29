using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Optons : MonoBehaviour
{
    List<string> opt = new List<string> { "LOW", "HIGH" };
    Dropdown drop;

    private void Start()
    {
        drop = GetComponent<Dropdown>();
        drop.ClearOptions();
        drop.AddOptions(opt);
    }
}
