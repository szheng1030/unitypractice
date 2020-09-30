using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home_GM : MonoBehaviour
{

    public static bool startGame;
    public float startDelay;

    private void Start()
    {
        startGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(startGame)
        {
            startDelay -= Time.deltaTime;
            if (startDelay < 0f)
            {
                SceneManager.LoadScene("Level_1");
            }
        }
    }
}
