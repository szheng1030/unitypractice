using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class win_home_button : MonoBehaviour
{
    public static GameObject winHomeButton;

    // Start is called before the first frame update
    void Start()
    {
        winHomeButton = gameObject;
        winHomeButton.SetActive(false);
    }
}
