using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignore_forInt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 9);
    }


}
