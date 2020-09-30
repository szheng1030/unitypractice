using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    public static bool gameWin;
    public static bool gameLose;

    private bool gameEnd;

    public Animator winAnimator;
    public Animator loseAnimator;
    public float loseDelay;
    private float loseDelayValue;

    public static bool retry;
    public Animator retryAnimator;
    public static bool failHome;
    public static bool winHome;
    public float endDelay;

    private void Start()
    {
        gameWin = false;
        gameLose = false;
        gameEnd = false;
        retry = false;
        failHome = false;
        winHome = false;
        loseDelayValue = loseDelay;
    }
    // Update is called once per frame
    void Update()
    {
        if (gameWin && !gameEnd)
        {
            winAnimator.SetBool("gameWin", true);
            gameEnd = true;
        }
        else if (gameLose && loseDelayValue < 0f)
        {
            gameEnd = true;
            loseAnimator.SetBool("gameLose", true);
        }
        else if (gameLose && !gameEnd)
        {
            loseDelayValue -= Time.deltaTime;
        }

        if (retry)
        {
            RetryPanel.retryPanel.SetActive(true);
            retryAnimator.SetBool("retry", true);
            endDelay -= Time.deltaTime;
            if (endDelay < 0f)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        if(failHome)
        {
            endDelay -= Time.deltaTime;
            if (endDelay < 0f)
            {
                SceneManager.LoadScene("Home");
            }
        }

        if(winHome)
        {
            endDelay -= Time.deltaTime;
            if (endDelay < 0f)
            {
                SceneManager.LoadScene("Home");
            }
        }
    }
}
