using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelup3 : MonoBehaviour
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
        if (levelupScore >= 1000)
        {
            Invoke("DelayedAction", 2);
        }
        
    }
    void DelayedAction()
    {
        SceneManager.LoadScene("Level 3");
    }
}
