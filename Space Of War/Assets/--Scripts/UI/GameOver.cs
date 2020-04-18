using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    //function called when playagain button is pressed
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level 1");
    }
    // function called when backtomain button is pressed and loads the main menu scene
    public void backtomain()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
