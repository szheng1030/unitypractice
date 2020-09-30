using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person1_GoalScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Person")
            GameMaster.gameWin = true;
    }
}
