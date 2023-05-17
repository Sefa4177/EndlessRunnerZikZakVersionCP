using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    #region Definitions
    public Text textClock;
    private float delta_time;
    public bool stopClock = false;
    public int timeScore;
    public static Clock instance;
    
    #endregion

    //bu script sadece oyundaki sürenin ilerlemesi ve gerektiğinde kullanılması için.
    private void Awake() 
    {
        if(instance)
        {
            Destroy(gameObject);
        }

        instance = this; 

        textClock = GetComponent<Text>(); 

        delta_time = 0;
        timeScore = 0;

        if (textClock == null) {
        Debug.LogError("textClock is not assigned in the inspector!");
    }
    }

    private void Start() 
    {
        stopClock = false;
    }

    private void Update() 
    {
        ClockMethod();
    }

    private void ClockMethod() // saat
    {
        if(stopClock == false)
        {
            delta_time += Time.deltaTime;
            TimeSpan span = TimeSpan.FromSeconds(delta_time);

            string hour = LeadingZero(span.Hours);
            string minute = LeadingZero(span.Minutes);
            string seconds = LeadingZero(span.Seconds);
            textClock.text = hour + ":" + minute + ":" + seconds;
        }      
    }

    string LeadingZero(int n) //string islemleri için method
    {
        return n.ToString().PadLeft(2, '0');
    }

}
