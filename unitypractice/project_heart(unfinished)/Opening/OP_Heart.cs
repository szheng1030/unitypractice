using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_Heart : MonoBehaviour
{
    public Animator anim;

    private float appearDelay = 1.0f;
    
    private void Update()
    {
        if (appearDelay > 0f)
            appearDelay -= Time.deltaTime;
        else if (appearDelay <= 0f)
            anim.SetBool("appear", true);
    }
}
