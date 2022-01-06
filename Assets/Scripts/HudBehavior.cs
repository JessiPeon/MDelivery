using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudBehavior : MonoBehaviour
{
    public Text powerUpText;
    public Text percentage;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        powerUpText.text = "Dics: " + LogicController.countPowerUp;
        percentage.text = LogicController.currentPercent + "% / " + LogicController.currentGoal + "%";
        score.text = LogicController.currentScore.ToString();
    }
}
