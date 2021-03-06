using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicController : MonoBehaviour
{
    public static int currentScore = 0;
    public static int countPowerUp = 0;
    public static int countHouses = 0;
    public static int countHousesByLevel = 0;
    public static bool fail = false;
    public static bool startedGame = false;
    private float time = 8.17f;//7.85f;

    public static int totalHouses = 24;
    public static int totalHouses1 = 24;
    public static int totalHouses2 = 39;
    public static int totalHouses3 = 37;
    public static int totalHouses4 = 40;
    public static int totalHouses5 = 38;

    public static int laps = 1;
    public static int maxLaps = 7;
    public static int round = 1;
    public static int maxRound = 2;

    public static int level = 1;
    public static int ultLevel = 6;
    public static bool finalLevel = false;

    public static int firstGoal = 50;
    public static int secondGoal = 50;
    public static int thirdGoal = 70;
    public static int fourthGoal = 70;
    public static int fifthtGoal = 100;
    public static int lastGoal = 100;
    public static int currentGoal =50;

    public static float firstVelocity = 1f;
    public static float secondVelocity = 1.5f;
    public static float thirdVelocity = 1.5f;
    public static float fourthVelocity = 2f;
    public static float fifthVelocity = 2f;
    public static float lastVelocity = 3f;
    public static float currentVelocity = firstVelocity;
    public Animator transition;

    public static int currentPercent = 0;

    void Awake()
    {
        fail = false;
        StartCoroutine(StartGameInTime(time));
    }

    // Update is called once per frame
    void Update()
    {
        if (startedGame)
        {
            currentScore = countPowerUp * 250 + countHouses * 100;
            if (fail)
            {
                FindObjectOfType<AudioController>().Mute("Instrumental");
                FindObjectOfType<AudioController>().Mute("ValetParking");
                startedGame = false;
                MenuController.EndGame();
            }
            var value = ((double)countHousesByLevel / totalHouses) * 100;
            currentPercent = Convert.ToInt32(Math.Round(value, 0));
            if (currentPercent > 100)
            {
                currentPercent = 100;
            }

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
        if (laps % maxLaps == 0)
        {
            round++;
            if (round > maxRound)
            {
                round = 1;
            }
            laps = 1;
        }

        //Debug.Log("lap " + laps + " round " + round + " level " + level);
    }

    public static void AddLevel()
    {
        level++;
        if (level == ultLevel)
        {
            finalLevel = true;
        }
        LogicController.currentPercent = 0;
        LogicController.countHousesByLevel = 0;
        SetVelocity();
        SetTotalHouses();
    }

    private static void SetVelocity()
    {
        if (level == 2)
        {
            currentVelocity = secondVelocity;
        }
        else
        {
            if (level == 3)
            {
            currentVelocity = thirdVelocity;
            }
            else
            {
                if (level == 4)
                {
                currentVelocity = fourthVelocity;
                }
                else
                {
                    if (level == 5)
                    {
                    currentVelocity = fifthVelocity;
                    }
                    else
                    {
                        if (level == 6)
                        {
                        currentVelocity = lastVelocity;
                        }
                    }
                }
            }
        }
    }

    private static void SetTotalHouses()
    {
        if (level == 2)
        {
            totalHouses = totalHouses2;
        }
        else
        {
            if (level == 3)
            {
                totalHouses = totalHouses3;
            }
            else
            {
                if (level == 4)
                {
                    totalHouses = totalHouses4;
                }
                else
                {
                    if (level == 5)
                    {
                        totalHouses = totalHouses5;
                    }
                    else
                    {
                        if (level == 6)
                        {
                            totalHouses = totalHouses5;
                        }
                    }
                }
            }
        }
    }

    public static void cleanVariables()
    {
        foreach (AudioSource s in GameObject.Find("AudioController").GetComponents<AudioSource>())
        {
            Destroy(s);
        }
        currentVelocity = firstVelocity;
        currentScore = 0;
        countPowerUp = 0;
        countHouses = 0;
        currentPercent = 0;
        countHousesByLevel = 0;
        fail = false;
        startedGame = false;
        totalHouses = totalHouses1;
        level = 1;
        round = 1;
        level = 1;
        laps = 2;
        currentGoal = firstGoal;
}

    public static bool isAddFinishLine()
    {
       Debug.Log("lap " + laps + " round " + round + " level " + level);
        //return (round == 3 && laps == 1 && level <= 6);
        return (round == maxRound && laps == 1 && !finalLevel);
    }

}
