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
        //collider.enabled = false;
        posFinalY = pos1.transform.position.y;

        
        if (!handLeft)
        {
            scrollSpeedX = -scrollSpeedX;
        }
        rb.velocity = new Vector2(scrollSpeedX, scrollSpeedY);
    }

    // Update is called once per frame
    void Update()
    {
        if(!handLeft && transform.position.y >= posFinalY + height)
        {
            Vector2 resetPosition = new Vector2(pos2.transform.position.x - 0.05f, pos2.transform.position.y + 0.18f);
            transform.position = resetPosition;
        }
        if (handLeft && transform.position.y >= posFinalY + height)
        {
            Vector2 resetPosition = new Vector2(pos2.transform.position.x + 0.07f, pos2.transform.position.y + 0.18f);
            transform.position = resetPosition;
        }
    }
}
