using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public GameObject game;
    public static bool shake = false;
    //public GameObject claws;

    float shakeAmount;

    private void Update()
    {
        if (shake)
        {
            Shake(0.3f, 0.05f);
            shake = false;
        }
    }

    public void Shake(float amt, float length)
    {
        shakeAmount = amt;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 gamePos = game.transform.position;
            //Vector3 clawsPos = claws.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            gamePos.x += offsetX;
            gamePos.y += offsetY;
            //clawsPos.x += (float)(offsetX * 0.6);
            //clawsPos.y += (float)(offsetY * 0.6);

            game.transform.position = gamePos;
            //claws.transform.position = clawsPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("BeginShake");
        game.transform.localPosition = Vector3.zero;
        //claws.transform.localPosition = Vector3.zero;
    }
}
