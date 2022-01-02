using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Animator transition;

    // Start is called before the first frame update
    public void StartGame()
    {
        FindObjectOfType<AudioController>().Play("Intro");
        StartCoroutine(LoadGameScene());
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

    IEnumerator LoadGameScene()
    {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Game"); 
    }

    public void ShowInputs()
    {
        GameObject.Find("Inputs").GetComponent<Image>().enabled = !(GameObject.Find("Inputs").GetComponent<Image>().enabled);
    }
}
