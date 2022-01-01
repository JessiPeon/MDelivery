using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    public bool handLeft;
    public GameObject pos1;
    public GameObject pos2;
    public String neighborhood;

    private float height;
    private float scrollSpeedY = 2.05f;
    private float scrollSpeedX = 0.18f;
    private float posFinalY;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        height = collider.size.y;
        collider.enabled = false;
        posFinalY = pos1.transform.position.y;

        
        if (!handLeft)
        {
            scrollSpeedX = -scrollSpeedX;
        }
        rb.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (LogicController.startedGame)
        {

            rb.velocity = new Vector2(scrollSpeedX * LogicController.currentVelocity, scrollSpeedY * LogicController.currentVelocity);
            if (!handLeft && transform.position.y >= posFinalY + height)
            {
                Vector2 resetPosition = new Vector2(pos2.transform.position.x - 0.05f, pos2.transform.position.y + 0.18f);
                transform.position = resetPosition;
                cleanNeighborhood();
            }
            if (handLeft && transform.position.y >= posFinalY + height)
            {
                Vector2 resetPosition = new Vector2(pos2.transform.position.x + 0.07f, pos2.transform.position.y + 0.18f);
                transform.position = resetPosition;
                cleanNeighborhood();
            }
        }
        
    }

    void cleanNeighborhood() { 
        foreach (var house in GameObject.FindGameObjectsWithTag("House"))  
        {
            if (neighborhood == house.GetComponent<HouseController>().neighborhood) //si es del mismo vecindario
            {
                house.GetComponent<SpriteRenderer>().enabled = false;
                house.GetComponent<HouseController>().done = false;
            }
        }
    }
}
