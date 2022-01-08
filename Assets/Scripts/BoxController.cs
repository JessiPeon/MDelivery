using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{

    public float speed = 7;
    public float direction = 1;
    private float currentTime = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Vector2.right * speed * LogicController.currentVelocity * Time.deltaTime);
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("House"))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            speed = 0;
        }

        if (other.gameObject.CompareTag("Carpet"))
        {
            if (!other.gameObject.GetComponent<HouseController>().done)
            {
                LogicController.countHouses++;
                LogicController.countHousesByLevel++;
                other.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                other.gameObject.GetComponent<HouseController>().done = true;
            }
        }

        if (other.gameObject.CompareTag("ColliderBox"))
        {
            direction = -direction;
        }
    }
}
