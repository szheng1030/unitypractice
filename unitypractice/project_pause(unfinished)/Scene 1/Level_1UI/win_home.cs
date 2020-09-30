using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win_home : MonoBehaviour
{
    public Animator animator;

    public void ButtonHit()
    {
        GameMaster.winHome = true;
        win_home_button.winHomeButton.SetActive(true);
        animator.SetBool("home", true);
        Destroy(gameObject);
    }
}
