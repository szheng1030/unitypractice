using UnityEngine;

public class FlowerPot : MonoBehaviour
{

    private Rigidbody2D rb;
    public float rotationSpeed;

    private bool isMoving = false;
    private float rotationSpeedValue;
    public static bool paused = false;

    private bool isBroken = false;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rotationSpeedValue = rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            if (PauseButton.hit)
            {
                if (!paused)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    rotationSpeed = 0f;
                    paused = true;
                    Debug.Log("Paused motion");
                }
                else
                {
                    rb.constraints = RigidbodyConstraints2D.None;
                    rotationSpeed = rotationSpeedValue;
                    paused = false;
                    Debug.Log("Restored motion");
                }
                PauseButton.hit = false;
            }
        }
        else if (!isMoving)
        {
            if (PauseButton.hit)
            {
                if (!paused)
                {
                    paused = true;
                    Debug.Log("Paused motion");
                }
                else if (paused)
                {
                    paused = false;
                    Debug.Log("Restored motion");
                }
                PauseButton.hit = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
            rb.rotation += 1.0f * rotationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bird")
        {
            if (!paused)
            {
                isMoving = true;
                transform.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            }
            if (paused)
            {
                Bird_Movement.isDead = true;
            }

        }
        if (col.tag == "Person")
        {
            col.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            isBroken = true;
            if (isBroken)
                animator.SetBool("isBroken", true);
            isMoving = false;
            Destroy(gameObject);
            Person_Movement.hitByFP = true;
        }
        if (col.tag == "Ground")
        {
            rb.rotation = 0;
            isBroken = true;
            if (isBroken)
                animator.SetBool("isBroken", true);
            isMoving = false;
        }
    }
}
