using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<AudioController>().Play("Intro");
    }

    public static void EndGame()
    {
        
        FindObjectOfType<AudioController>().Play("Outro");
        SceneManager.LoadScene("Outro");
    }

    public void Restart()
    {
        LogicController.cleanVariables();
        FindObjectOfType<AudioController>().RestartAudioController();
        SceneManager.LoadScene("Intro");
    }
}
