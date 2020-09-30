using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CH1_Heart : MonoBehaviour
{
    public Animator anim;
    public float speed;

    private bool inProximity = false;

    private bool abandoning = true;
    public static bool abandonded = false;
    private float abandonTimer = 30.0f;
    public static bool isGone = false;

    private float approachTimer = 3.0f;
    public static bool approached = false;

    private float warmTimer = 20.0f;
    private float coldTimer = 10.0f;
    public static bool warm = false;
    public static bool cold = false;
    public static bool isCold = false;
    public static bool resetPos = false;

    private float distance;

    private void OnMouseEnter()
    {
        inProximity = true;
        if (abandoning)
            abandoning = false;
    }

    private void OnMouseExit()
    {
        inProximity = false;
    }


    private void Update()
    {
        distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 2) +
            Mathf.Pow(transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 2));

        if (abandoning)
            abandonTimer -= Time.deltaTime;
        if (abandonTimer <= 0f)
            abandonded = true;
        if (isGone)
            anim.SetBool("disappear", true);

        if (inProximity)
        {
            transform.position = Vector2.MoveTowards(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), -speed * Time.deltaTime);
            approachTimer -= Time.deltaTime;
        }
        if (approachTimer <= 0f)
            approached = true;

        if (CH1_GM.current == CH1_GM.State.Approached)
        {
            if (distance <= 0.3)
                isCold = true;
            else if (distance > 0.3)
                isCold = false;

            if (inProximity && !isCold && (CH1_GM.currentLine == 60 || CH1_GM.currentLine == 61 || CH1_GM.currentLine == 62))
                warmTimer -= Time.deltaTime;
            else if (isCold && (CH1_GM.currentLine == 60 || CH1_GM.currentLine == 61 || CH1_GM.currentLine == 62))
            {
                coldTimer -= Time.deltaTime;
                warmTimer += Time.deltaTime / 2;
            }

            if (coldTimer < 6.0f && warmTimer > 10.0f)
                speed = 0.5f;
            else if (warmTimer < 10.0f && coldTimer > 6.0f)
                speed = 0.1f;

            if (warmTimer <= 0f)
            {
                warm = true;
                coldTimer = 300.0f;
                resetPos = true;
            }
            else if (coldTimer <= 0f)
            {
                cold = true;
                warmTimer = 300.0f;
                resetPos = true;
            }
        }

        if (CH1_GM.current == CH1_GM.State.Warm || CH1_GM.current == CH1_GM.State.Cold)
        {
            if (resetPos)
            {
                    transform.position = Vector2.MoveTowards(transform.position, new Vector3(0, 2), 0.3f * Time.deltaTime);
            }
        }
    }
}
