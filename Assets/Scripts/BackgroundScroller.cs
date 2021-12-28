using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    public bool handLeft;
    public GameObject height_sprite;

    private float height;
    private float scrollSpeedY = 2f;
    private float scrollSpeedX = 0.18f;
    private float posFinalY;
    private float posFinalX;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        height = collider.size.y;//height_sprite.transform.localScale.y;
        posFinalY = transform.position.y + height; // no puedo depender de transform.position.y porque en los dos pedazos es dif
        posFinalX = -transform.position.x;
        
        collider.enabled = false;
        if (!handLeft)
        {
            scrollSpeedX = -scrollSpeedX;
        }
        rb.velocity = new Vector2(scrollSpeedX, scrollSpeedY);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= posFinalY)
        {
            Debug.Log("Hola");
            Vector2 resetPosition = new Vector2(0, -posFinalY *2f);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
