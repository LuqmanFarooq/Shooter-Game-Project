using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelup2 : MonoBehaviour
{
    // refrence to score text ui object
    public GameObject scoreUIText;
    // Start is called before the first frame update
    void Start()
    {
        // get the score text UI
        scoreUIText = GameObject.FindGameObjectWithTag("ScoreTextTag");
        
    }

    // Update is called once per frame
    void Update()
    {
        int levelupScore;
        levelupScore = scoreUIText.GetComponent<GameScore>().Score;
        // if score is greater than 500 it moves to level 2
        if (levelupScore > 500)
        {
            Invoke("DelayedAction", 1);    
        }
        
    }
    void DelayedAction ()
    {
        SceneManager.LoadScene("Level 2");
        
    }
}
