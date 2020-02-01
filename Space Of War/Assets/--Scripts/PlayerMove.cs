using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // == public fields ==

    // this is our player bullet prefab
    public GameObject PlayerBullet;
    public GameObject bulletposition1;
    // == private fields ==
    private Rigidbody2D rb;
    private Transform t;
    [SerializeField] private float speed = 5.0f;
    // == public methods ==

    // == private methods ==
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        // fire bullets when spacebar is pressed
        if(Input.GetKeyDown("space"))
        {
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
}
