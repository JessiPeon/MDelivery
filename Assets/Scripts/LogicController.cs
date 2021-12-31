using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicController : MonoBehaviour
{
    public static int countPowerUp = 0;
    public static int countLoopStreet = 0;
    public static bool fail = false;
    public static bool startedGame = false;

    // Start is called before the first frame update
    void Awake()
    {        
        
        StartCoroutine(StartGameInTime(9.5f));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LogicController.startedGame)
        {
            if (fail)
            {
                MenuController.EndGame();
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
}
