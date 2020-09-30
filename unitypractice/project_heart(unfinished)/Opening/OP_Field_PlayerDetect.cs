using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_Field_PlayerDetect : MonoBehaviour
{
    public static bool PlayerDetected = false;

    private void OnMouseEnter()
    {
        PlayerDetected = true;
    }
}
