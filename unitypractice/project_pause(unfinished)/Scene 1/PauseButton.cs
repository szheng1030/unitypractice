using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    public static bool hit;

    private void Start()
    {
        hit = false;
    }

    public void ButtonHit()
    {
        hit = true;
    }
}
