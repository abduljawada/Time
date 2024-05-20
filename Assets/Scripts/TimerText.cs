using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class TimerText : MonoBehaviour
{
    [SerializeField] int startTime = 180;
    [SerializeField] TextMeshProUGUI text;
    float remainingTime;


    private void Awake()
    {
        remainingTime = startTime;
    }
    private void Update()
    {
        remainingTime -= Time.deltaTime;
        string minutes = ((int)remainingTime / 60).ToString();
        string seconds = ((int) remainingTime % 60).ToString();

        text.text = minutes + ":" + seconds;

        if (remainingTime <= 0)
        {
            GameManager.instance.Lose();
        }
    }
}
