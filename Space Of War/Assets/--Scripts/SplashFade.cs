using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SplashFade : MonoBehaviour
{
    public Image splashImage;

    IEnumerator Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);

        FadeIn();
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(2.5f);
        // scene we wnat to load after splash screen
        SceneManager.LoadScene("Main Menu");
    }
    
    void FadeIn()
    {
        // fade the alph for 0 to 100 % for 1.5 seconds
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        // it reverses from 100 % fade to 0
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
