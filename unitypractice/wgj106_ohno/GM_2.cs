using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_2 : MonoBehaviour
{
    public GameObject[] Tile_16x16;
    public Animator anim;

    private int counter_16x16;

    void Start()
    {
        for (int i = 0; i < 256; i++)
            Tile_16x16[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 4) * 90);
        StartCoroutine(EndDelay(6.0f));
    }

    IEnumerator EndDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("end", true);
    }
    
}
