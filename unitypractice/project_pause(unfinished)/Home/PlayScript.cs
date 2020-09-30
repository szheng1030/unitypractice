using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScript : MonoBehaviour
{

    public Animator animator;

    public void ButtonPlayHit()
    {
        animator.SetBool("play", true);
        Home_GM.startGame = true;
    }
}
