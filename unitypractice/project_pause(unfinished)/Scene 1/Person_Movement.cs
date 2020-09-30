using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person_Movement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    public Animator animator;
    public static bool hitByFP;

    public float startDelay;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitByFP = false;
    }

    // Update is called once per frame
    void Update()
    {
        startDelay -= Time.deltaTime;

        if (startDelay < 0f)
            rb.velocity = new Vector2(1.0f * speed, 0f);

        if (hitByFP)
        {
            animator.SetBool("isHit", true);
            GameMaster.gameLose = true;
        }
    }
}
