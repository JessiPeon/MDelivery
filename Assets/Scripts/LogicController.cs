using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicController : MonoBehaviour
{
    public static int countPowerUp = 0;
    public static int countHouses = 0;
    public static bool fail = false;
    public static bool startedGame = false;
    private float time = 9.65f;
    public static int totalHouses = 40;
    public static int laps = 1;
    public static int round = 1;

    public static int level = 1;

    public static int firstGoal = 50;
    public static int secondGoal = 50;
    public static int thirdGoal = 70;
    public static int fourthGoal = 70;
    public static int fifthtGoal = 100;
    public static int lastGoal = 100;
    public static int currentGoal;

    public static float firstVelocity = 1f;
    public static float secondVelocity = 1.25f;
    public static float thirdVelocity = 1.25f;
    public static float fourthVelocity = 1.5f;
    public static float fifthVelocity = 1.5f;
    public static float lastVelocity = 1.8f;
    public static float currentVelocity = firstVelocity;
    public static int currentPercent = 0;


    // Start is called before the first frame update
    void Awake()
    {
        fail = false;
        StartCoroutine(StartGameInTime(0.1f));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startedGame)
        {
            if (fail)
            {
                FindObjectOfType<AudioController>().Mute("Instrumental");
                FindObjectOfType<AudioController>().Mute("ValetParking");
                startedGame = false;
                MenuController.EndGame();
            }
            var value = ((double)countHouses / totalHouses) * 100;
            currentPercent = Convert.ToInt32(Math.Round(value, 0));

            if (level == 1)
            {
                currentGoal = firstGoal;
            }
            else
            {
                if (level == 2)
                {
                    currentGoal = secondGoal;
                }
                else
                {
                    if (level == 3)
                    {
                        currentGoal = thirdGoal;
                    }
                    else
                    {
                        if (level == 4)
                        {
                            currentGoal = fourthGoal;
                        }
                        else
                        {
                            if (level == 5)
                            {
                                currentGoal = fifthtGoal;
                            }
                            else
                            {
                                if (level == 6)
                                {
                                    currentGoal = lastGoal;
                                }
                            }
                        }
                    }
                }
            }
        }

    }


    IEnumerator StartGameInTime (float time)
    {
        yield return new WaitForSeconds(time);
        startedGame = true;
        FindObjectOfType<AudioController>().Play("Instrumental");
        FindObjectOfType<AudioController>().Mute("Instrumental");
        FindObjectOfType<AudioController>().Play("ValetParking");
    }

    public static void AddLap()
    {
        laps += 1;
        if (laps % 7 == 0)
        {
            round++;
            if (round > 3)
            {
                round = 1;
            }
            laps = 1;
        }

        Debug.Log("lap " + laps + " round " + round + " level " + level);
    }

    public static void AddLevel()
    {
        level++;
        //set config
    }


    public static void cleanVariables()
    {
        foreach (AudioSource s in GameObject.Find("AudioController").GetComponents<AudioSource>())
        {
            Destroy(s);
        }
    }

    public static void checkGoal(int goal)
    {
        
    }
}
