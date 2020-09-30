using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GM GM;

    public void Click()
    {
        transform.Rotate(0, 0, -90, Space.Self);
        GM.CheckWin();
    }
    
}
