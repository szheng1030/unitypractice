using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public GameObject[] Tile_4x4;
    public GameObject ohno_base;
    public GameObject claws;
    public GameObject panel;
    public AudioSource ohno;
    public AudioSource meow;
    public AudioSource paa;
    public Animator anim;

    private CameraShake camshake;
    private int counter_4x4;

    void Start()
    {
        camshake = GetComponent<CameraShake>();
        for (int i = 0; i < 16; i++)
            Tile_4x4[i].transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 4) * 90);
    }

    public void CheckWin()
    {
        counter_4x4 = 0;

        for (int i=0; i<16; i++)
        {
            if (Tile_4x4[i].transform.rotation == new Quaternion (0, 0, 0, 1.0f) ||
                Tile_4x4[i].transform.rotation == new Quaternion(0, 0, 0, -1.0f))
            {
                counter_4x4++;
            }
        }

        if (counter_4x4 == 16)
            StartCoroutine(Ohno(1.0f));
    }

    IEnumerator Ohno(float waitTime)
    {
        ohno_base.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        ohno.Play();
        StartCoroutine(Meow(1.0f));
    }

    IEnumerator Meow(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        meow.Play();
        StartCoroutine(Claws(1.5f));
    }

    IEnumerator Claws(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        claws.SetActive(true);
        paa.Play();
        CameraShake.shake = true;
        StartCoroutine(Fade(0.3f));
    }

    IEnumerator Fade(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        panel.SetActive(true);
        anim.SetBool("fade", true);
        StartCoroutine(SceneChangeDelay(3.0f));
    }

    IEnumerator SceneChangeDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
