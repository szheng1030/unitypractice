using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    public static float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 10f;
            SceneManager.LoadScene("End");
        }
            
    }
}
