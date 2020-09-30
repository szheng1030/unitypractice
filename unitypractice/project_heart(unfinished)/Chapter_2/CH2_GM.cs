using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CH2_GM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("Warm/Cold"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
