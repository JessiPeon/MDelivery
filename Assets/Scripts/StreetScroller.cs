using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetScroller : MonoBehaviour
{
    public Rigidbody2D rb;
    //public GameObject powerUp;
    public GameObject pos1;
    public GameObject pos2;

    public GameObject finishLine;

    private float scrollSpeedY = 2f;
    private float posFinalY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = new Vector2(0, 0);

        posFinalY = pos1.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (LogicController.startedGame)
        {
            rb.velocity = new Vector2(0, scrollSpeedY * LogicController.currentVelocity);
            if (transform.position.y > posFinalY)
            {
                Vector2 resetPosition = new Vector2(0, pos2.transform.position.y);
                transform.position = resetPosition;
                resetPowerUp();
                LogicController.AddLap();
                if(LogicController.isAddFinishLine())
                {
                    LogicController.currentPercent = 0;
                    Vector2 position = new Vector2(finishLine.transform.position.x, finishLine.transform.position.y);
                    Instantiate(finishLine, position, Quaternion.identity, gameObject.transform);
                }

            }

            if (transform.childCount > 0 && transform.GetChild(0).name == "PowerUp")
            {
                if ((transform.GetChild(0).transform.position.y >= GameObject.Find("LimitBottom").transform.position.y) && transform.GetChild(0).GetComponent<BoxCollider2D>().enabled)
                {
                    FindObjectOfType<AudioController>().Mute("ValetParking");
                    FindObjectOfType<AudioController>().UnMute("Instrumental");
                }
            }
        }
    }

    void resetPowerUp()
    {
        if (transform.childCount > 0 && transform.GetChild(0).name == "PowerUp") {
            transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
            transform.GetChild(0).localPosition = new Vector3(UnityEngine.Random.Range(-3, 3), 0, 0);
        }
    }

    
}
