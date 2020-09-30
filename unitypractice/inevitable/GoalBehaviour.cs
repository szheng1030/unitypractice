using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{

    public static bool timer10s = false;
    public static bool timer7s = false;
    public static bool timer5s = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScoreCounter.score++;
            Destroy(gameObject);
            GoalSpawn.goalTouched = true;
            if (ScoreCounter.score < 10)
            {
                GameMaster.timer = 10f;
                timer10s = true;
            }
            else if (ScoreCounter.score >= 10 && ScoreCounter.score < 20)
            {
                GameMaster.timer = 7f;
                timer7s = true;
            }
            else if (ScoreCounter.score >= 20)
            {
                GameMaster.timer = 5f;
                timer5s = true;
            }
        }
    }
}
