using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    // this is our star prefab
    public GameObject star;

    // maximum number of stars
    public int maxStars;

    // array of colours
    Color[] starColors =
    {
        new Color (1f,1f,0f), // yellow
        new Color (1f,0f,0f), // red
        new Color (0f,1f,1f), // green
        new Color (0.5f,0.5f,1f), // blue
    };

    // Start is called before the first frame update
    void Start()
    {
        //this is the bottom left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        // this is the top-right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        //loop to create the stars
        for(int i=0;i< maxStars; i++)
        {
            GameObject stars = (GameObject)Instantiate(star);

            // set the star color 
            stars.GetComponent<SpriteRenderer>().color = starColors[i % starColors.Length];

            // set the position of the star
            stars.transform.position = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

            // set the random speed for the star
            stars.GetComponent<Star>().speed = -(1f * Random.value + 0.5f);

            // make the star a child of the star generator
            stars.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
