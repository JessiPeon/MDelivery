using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudBehavior : MonoBehaviour
{
    public Text powerUpText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        powerUpText.text = "Dics: " + LogicController.countPowerUp;
    }
}
