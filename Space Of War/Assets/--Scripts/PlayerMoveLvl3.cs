using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMoveLvl3 : MonoBehaviour
{

    // == public fields ==
    // refrence to game object enemy spawner
    public GameObject enemySpawner;
    // refrence to our gameover object
    public GameObject gameOver;
    // refrence to score text ui object
    public GameObject scoreTextUI;
    // this is our player bullet prefab
    public GameObject PlayerBullet;
    public GameObject bulletposition1;
    // explosion prefab
    public GameObject Explosion;
    // == private fields ==
    private Rigidbody2D rb;
    private Transform t;
    [SerializeField] private float speed = 5.0f;

    // Refrence to the lives UI text
    public Text LivesUIText;
    // maximum lives of player
    const int MaxLives = 3;
    // current lives of player
    public int lives;
    // == public methods ==

    // == private methods ==
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lives = MaxLives;

        // update the lives UI text
        LivesUIText.text = lives.ToString();
        // reset the score
        scoreTextUI.GetComponent<GameScore>().Score = 1000;
        // set this player game object to active
        gameObject.SetActive(true);
        // reset the player position to the centere of the screen
        transform.position = new Vector2(0, -2);
    }

    // Update is called once per frame
    void Update()
    {
        // fire bullets when spacebar is pressed
        if (Input.GetKeyDown("space"))
        {
            // play the laser sound effect
            gameObject.GetComponent<AudioSource>().Play();
            // instantiate main bullet
            GameObject mainBullet = (GameObject)Instantiate(PlayerBullet);
            // set the bullet initial position
            mainBullet.transform.position = bulletposition1.transform.position;
        }
        // add horizontal Movement
        float hMovement = Input.GetAxis("Horizontal");
        // if the player presses the up arrow then move
        float vMovement = Input.GetAxis("Vertical");
        // apply a force,get the player moving.
        rb.velocity = new Vector2(hMovement * speed, vMovement * speed);

        /* if(Input.GetKeyDown(KeyCode.Space))
         {
             FireBullet();
         }
         if(Input.GetKeyUp(KeyCode.Space))
         {
             StopFire();
         }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detect collision of the player ship with an enemy ship , or enemy bullet
        if ((collision.tag == "EnemyShipTag") || (collision.tag == "EnemyBulletTag"))
        {
            showExplosion();
            // subtract a life upon collision
            lives--;
            // update lives UI text
            LivesUIText.text = lives.ToString();
            // if the player is dead
            if (lives == 0)
            {
                // destroy player ship
                Destroy(gameObject);
                // stop enemy spawner after player dies and have 0 remaining lives
                enemySpawner.GetComponent<EnemySpawner>().stopEnemySpawner();
                // change the game manager state to game over state
                gameOver.SetActive(true);
            }

        }//if
    }

    // function to instantiate explosion
    void showExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(Explosion);

        // setting the position of the explosion
        explosion.transform.position = transform.position;
    }
}

