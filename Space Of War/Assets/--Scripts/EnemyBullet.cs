using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // the bullet speed
    float speed;
    // the direction of the bullet
    Vector2 bDirection;
    // to know when the bullet direction is set
    bool isReady;

    // set the default values in awake function
    void Awake()
    {
        speed = 5f;
        isReady = false;
    }
    void Start()
    {
        
    }
    // function to set the bullet's direction
    public void SetDirection(Vector2 direction)
    {
        // set the direction nomalized, to  get an unit vector
        bDirection = direction.normalized;

        // set flag to true
        isReady = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(isReady)
        {
            //get  the bullet's current position
            Vector2 position = transform.position;

            // compute the bullet's new position
            position += bDirection * speed * Time.deltaTime;

            // update the bullet's position
            transform.position = position;

            //i need to remove the bullet from our game
            // if the bullet goes outside the screen

            // this is the bottom-left  point of the screen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            // this is the top-right point of the screen
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            // if the bullet goes outside the screen, then destroy it
            if ((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // detect collision of an enemy bullet with the player ship
        if(collision.tag == "PlayerShipTag")
        {
            // destroy this bullet
            Destroy(gameObject);
        }
    }
}
