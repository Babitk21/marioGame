using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeScript : MonoBehaviour
{
    private float timeInitial = 10;
    public TextMeshProUGUI timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeInitial -= Time.deltaTime;
        timer.text = "Time = " + Mathf.RoundToInt(timeInitial).ToString();
    }
}
