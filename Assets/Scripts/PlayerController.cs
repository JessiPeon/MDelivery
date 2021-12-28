using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedX = 5;
    public float speedY = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveDirectionY = Input.GetAxis("Vertical");
        float moveDirectionX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirectionX * speedX, moveDirectionY * speedY);
    }
}
