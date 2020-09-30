using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose_Home : MonoBehaviour
{
    public Animator animator;

    public void ButtonHit()
    {
        GameMaster.failHome = true;
        fail_home_button.failHomeButton.SetActive(true);
        animator.SetBool("home", true);
        Destroy(gameObject);
    }
}
