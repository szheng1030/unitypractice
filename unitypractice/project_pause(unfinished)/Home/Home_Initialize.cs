using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_Initialize : MonoBehaviour
{
    private float destroyCD;

    private void Start()
    {
        destroyCD = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        destroyCD -= Time.deltaTime;
        if (destroyCD < 0f)
            Destroy(gameObject);
    }
}
