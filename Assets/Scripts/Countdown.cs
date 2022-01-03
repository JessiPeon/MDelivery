using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    private float currentTime = 5f;
    public Text countdown;
    void Start()
    {
        //currentTime += 1 * Time.deltaTime;
    }

    void Update()
    {
        //gameObject.GetComponent<Animator>().SetTrigger
        StartCoroutine(ShowCountdownInTime(1.5f));
    }

    IEnumerator ShowCountdownInTime (float time)
    {
        yield return new WaitForSeconds(time);

        currentTime -= 1 * Time.deltaTime;
        GameObject.Find("Countdown").GetComponent<Animator>().SetTrigger("start");
        var timeToShow = (float)Math.Round(currentTime,0);
        GameObject.Find("Countdown").GetComponent<Text>().fontSize = 50;
        if (timeToShow <= 0)
        {
            countdown.text = "Go!";
            GameObject.Find("Countdown").GetComponent<Animator>().SetTrigger("end");
            
        }
        else
        {
            if (timeToShow >= 4)
            {
                GameObject.Find("Countdown").GetComponent<Text>().fontSize = 25;
                countdown.text = "Ready?";
            } else
            {
                if (timeToShow <= 1)
                {
                    timeToShow = 1f;
                }
                countdown.text = timeToShow.ToString("0");
            }
            
        }
    }

}
