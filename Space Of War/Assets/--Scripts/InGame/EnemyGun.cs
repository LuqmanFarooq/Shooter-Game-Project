using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    // this is our enemy bullet prefab
    public GameObject EnemyBullet;
    // Start is called before the first frame update
    void Start()
    {
        // fire an enemy bullet after 1 second
        Invoke("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to fire enemy bullet
    void FireEnemyBullet()
    {
        // get a reference to the players ship
        GameObject playerShip = GameObject.Find("player");

        //if the player is not dead
        if(playerShip !=null)
        {
            // instantiate an enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBullet);

            // set the bullets initial position
            bullet.transform.position = transform.position;

            //compute the bullet's direction towards player's ship
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //set the bullet's direction
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
