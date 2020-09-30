using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Person")
        {
            col.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            Debug.Log("The person has avoided the flower pot");
        }
    }
}
