using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the bullets current position
        Vector2 position = transform.position;

        // compute  the bullets new position
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        // update the bullet's position
        transform.position = position;

        // destroy bullet when it move out of the screen

        // this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //if the bullet goes outside the screen then destroy it
        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // detect collision of the player bullet with an enemy ship
        if(collision.tag == "EnemyShipTag")
        {
            // Destroy this player Bullet
            Destroy(gameObject);
        }
    }
}
