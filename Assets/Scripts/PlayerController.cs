using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedX = 5;
    public float speedY = 3;
    public string lastDir = "right";

    public GameObject box;
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            var direction = 1;
            if (lastDir == "left")
            {
                direction = -1;
            }
            box.GetComponent<BoxController>().direction = direction;
            Vector2 positionBox = new Vector2(transform.position.x, transform.position.y);
            Instantiate(box, positionBox, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            lastDir = "left";
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            lastDir = "right";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            LogicController.countPowerUp += 1;
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
