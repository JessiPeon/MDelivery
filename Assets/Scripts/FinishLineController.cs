using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineController : MonoBehaviour
{
    private int goal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 6);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name=="Player")
        {
            //LogicController.AddLevel();
            if (LogicController.currentPercent >= LogicController.currentGoal)
            {
                LogicController.AddLevel();
            } else
            {
                LogicController.fail = true;
            }
            
        }
    }
}
