using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    // Start is called before the first frame update
    public String neighborhood;
    public bool done = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LimitTop") && LogicController.currentGoal == 100 && LogicController.level >= LogicController.ultLevel && !done)
        {
            LogicController.fail = true;
        }
    }
}
