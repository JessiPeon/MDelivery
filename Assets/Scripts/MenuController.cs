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
        SceneManager.LoadScene("Outro");
    }

    public void Restart()
    {
        //limpiar variables
        SceneManager.LoadScene("Intro");
    }
}
