using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    // refrence to the text ui game object
    GameObject scoreUIText;
    
    // explosion prefab
    public GameObject Explosion;
    // enemy speed
    float speed;
   
    // Start is called before the first frame update
    
    void Start()
    {

        // setting speed
        speed = 2f;
        // get the score text UI
        scoreUIText = GameObject.FindGameObjectWithTag("ScoreTextTag");
        
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // detect collision of the enemy ship with the player ship or with player bullet
        if((collision.tag == "PlayerShipTag") || (collision.tag == "PlayerBulletTag"))
        {
            //destroy enemy ship
            {
                showExplosion();
                // add 55 points to the score
                scoreUIText.GetComponent<GameScore>().Score += 55;
                // destroy enemy ship
                Destroy(gameObject);
                
            }
        }
    }

    // function to instantiate enemy explosion
    void showExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        // setting the position of explosion
        explosion.transform.position = transform.position;
    }
}
