using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // enemy speed
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        // setting speed
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        // getting enemy current position
        Vector2 position = transform.position;

        // compute new enemy position
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);

        // upadting enemy position
        transform.position = position;

        // this is the bottom point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // if enemy went outside the screen then destroy the enemy object
        if(transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
}
