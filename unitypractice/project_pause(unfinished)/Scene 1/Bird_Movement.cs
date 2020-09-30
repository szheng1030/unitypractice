using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird_Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float xSpeed, ySpeed;
    public float flightDelay;

    private bool isFlying;
    public Animator animator;

    public static bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
        isFlying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            flightDelay -= Time.deltaTime;
            if (flightDelay < 0f)
            {
                if (!isFlying)
                {
                    isFlying = true;
                    animator.SetBool("isFlying", true);
                }
                rb.velocity = new Vector2(1.0f * xSpeed, 1.0f * ySpeed);
            }
        }
        else
        {
            if (rb.constraints == RigidbodyConstraints2D.None)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                Debug.Log("Bird is dead.");
                animator.SetBool("isDead", true);
                GameMaster.gameLose = true;
            }
        }
    }
}
