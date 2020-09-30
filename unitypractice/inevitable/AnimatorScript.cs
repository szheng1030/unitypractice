using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalBehaviour.timer10s)
        {
            anim.Play("Fade_10s", -1, 0f);
            GoalBehaviour.timer10s = false;
        }
        else if (GoalBehaviour.timer7s)
        {
            anim.Play("Fade_7s", -1, 0f);
            GoalBehaviour.timer7s = false;
        }
        else if (GoalBehaviour.timer5s)
        {
            anim.Play("Fade_5s", -1, 0f);
            GoalBehaviour.timer5s = false;
        }

    }
}
