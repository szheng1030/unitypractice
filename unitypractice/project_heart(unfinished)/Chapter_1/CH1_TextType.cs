using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CH1_TextType : MonoBehaviour
{
    public float speed;

    private TextMeshProUGUI tmp;

    public AudioSource voiceSFX;
    private bool isTalking = false;
    public float delaySFX;
    private float delaySFXTimer;

    private void Start()
    {
        tmp = gameObject.GetComponent<TextMeshProUGUI>();
        voiceSFX = gameObject.GetComponent<AudioSource>();

        tmp.maxVisibleCharacters = 27;
        tmp.SetText("CHAPTER 1: Just a passerby.");

        delaySFXTimer = delaySFX;
    }

    IEnumerator PrintLine()
    {
        isTalking = true;
        for (int i = 0; i < (tmp.textInfo.characterCount + 1); i++)
        {
            tmp.maxVisibleCharacters = i;

            yield return new WaitForSeconds(speed);
        }
        isTalking = false;
    }

    public void UpdateLine()
    {
        StopAllCoroutines();
        tmp.SetText(CH1_Dialogue.text[CH1_GM.currentLine]);
        StartCoroutine(PrintLine());
    }

    private void Update()
    {
        delaySFXTimer -= Time.deltaTime;

        if (isTalking && delaySFXTimer <= 0)
        {
            voiceSFX.Play();
            delaySFXTimer = delaySFX;
        }
    }
}
