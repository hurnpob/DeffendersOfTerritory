using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeLeft;
    [SerializeField] bool timerOn;
    public TextMeshPro timerText;

    void Start()
    {
        timerOn = true;
        timerText = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        UpdateTimer(timeLeft);
        if(timerOn)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            Debug.Log("Time Is Over");
            timeLeft= 0;
            timerOn= false;
        }
    }

    private void UpdateTimer(float CurrentTime)
    {
        float minutes = Mathf.FloorToInt(CurrentTime / 60);
        float seconds = Mathf.FloorToInt(CurrentTime % 60);
       // timerText.text = string.Format("{00:00} : {01:00}", minutes, seconds);   
    }
}
