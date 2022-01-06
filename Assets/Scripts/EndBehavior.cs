using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndBehavior : MonoBehaviour
{
    public Text score;

    void Start()
    {
        score.text = "+"+LogicController.currentScore.ToString();
    }


}
