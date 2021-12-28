using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetScroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject pos1;
    public GameObject pos2;

    private float scrollSpeedY = 2f;
    private float posFinalY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.velocity = new Vector2(0, scrollSpeedY);

        posFinalY = pos1.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > posFinalY)
        {
            Vector2 resetPosition = new Vector2(0, pos2.transform.position.y);
            transform.position =  resetPosition;
        }
    }
}
