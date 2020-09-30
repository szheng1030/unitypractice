using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryButton : MonoBehaviour
{

    public Animator animator;

    public void ButtonHit()
    {
        animator.SetBool("retry", true);
        GameMaster.retry = true;
    }
}
