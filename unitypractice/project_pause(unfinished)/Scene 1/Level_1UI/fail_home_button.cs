using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fail_home_button : MonoBehaviour
{

    public static GameObject failHomeButton;

    // Start is called before the first frame update
    void Start()
    {
        failHomeButton = gameObject;
        failHomeButton.SetActive(false);
    }

}
