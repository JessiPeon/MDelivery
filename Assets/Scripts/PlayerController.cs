using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speedX = 5;
    public float speedY = 3;
    public string lastDir = "right";
    public Animator animator;

    private float nextBox = 0.0f;

    public GameObject box;
    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (LogicController.startedGame)
        {
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            var speed_X = speedX * LogicController.currentVelocity;
            var speed_Y = speedY * LogicController.currentVelocity;
            float moveDirectionY = Input.GetAxis("Vertical");
            float moveDirectionX = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveDirectionX * speed_X, moveDirectionY * speed_Y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                ThrowBox();
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
    }

    private void ThrowBox()
    {
        if (Time.time > nextBox)
        {
            nextBox = Time.time + 0.5f;

            var direction = 1;
            if (lastDir == "left")
            {
                direction = -1;
                box.GetComponent<SpriteRenderer>().flipX = false;
            } else
            {
                box.GetComponent<SpriteRenderer>().flipX = true;
            }
            box.GetComponent<BoxController>().direction = direction;
            Vector2 positionBox = new Vector2(transform.position.x, transform.position.y);
            Instantiate(box, positionBox, Quaternion.identity);

        }
       

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            FindObjectOfType<AudioController>().Mute("Instrumental");
            FindObjectOfType<AudioController>().UnMute("ValetParking");

            LogicController.countPowerUp += 1;
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
