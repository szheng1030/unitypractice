using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CH1_GM : MonoBehaviour
{
    public enum State
    {
        Start,
        Idle,
        Approached,
        Abandonded,
        Warm,
        Cold,
    }

    public static int currentLine = 0;
    public CH1_TextType textType;
    public GameObject Heart;
    public Rigidbody2D Heart_rb;
    
    public static State current = State.Start;
    private float startDelay = 2.0f;

    private float abandonDelay = 1.0f;
    private float approachDelay = 1.0f;
    private float warmDelay = 1.0f;
    private float coldDelay = 1.0f;

    public static float outroDelay = 5.0f;

    private void Update()
    {
        if (current == State.Start && startDelay > 0f)
            startDelay -= Time.deltaTime;
        else if (current == State.Start && startDelay <= 0f)
        {
            textType.UpdateLine();
            currentLine++;
            current = State.Idle;
        }

        if (CH1_Heart.abandonded)
        {
            Heart_rb.constraints = RigidbodyConstraints2D.FreezeAll;
            Cursor.lockState = CursorLockMode.Locked;
            current = State.Abandonded;
        }
        if (current == State.Abandonded)
        {
            abandonDelay -= Time.deltaTime;

            if ((currentLine == 1 || currentLine == 13 || currentLine == 54) && abandonDelay <= 0f)
                NextLine(5.0f);
            else if ((currentLine == 23 || currentLine == 24 || currentLine == 28 || currentLine == 29 || currentLine == 30 || currentLine == 31 || currentLine == 32 || currentLine == 33 || currentLine == 34 || currentLine == 35) && abandonDelay <= 0f)
                NextLine(2.0f);
            else if ((currentLine == 2 || currentLine == 3 || currentLine == 44) && abandonDelay <= 0f)
                NextLine(2.5f);
            else if ((currentLine == 5 || currentLine == 36 || currentLine == 47) && abandonDelay <= 0f)
                NextLine(4.0f);
            else if ((currentLine == 9 || currentLine == 10 || currentLine == 11) && abandonDelay <= 0f)
                NextLine(6.0f);
            else if ((currentLine == 7 || currentLine == 14 || currentLine == 48 || currentLine == 49 || currentLine == 50) && abandonDelay <= 0f)
                NextLine(7.0f);
            else if (currentLine == 41 && abandonDelay <= 0f)
            {
                NextLine(7.0f);
                CH1_Heart.isGone = true;
            }
            else if (currentLine <= 55 && abandonDelay <= 0f)
                NextLine(3.0f);
        }

        if (CH1_Heart.approached && current == State.Idle)
        {
            currentLine = 56;
            current = State.Approached;
        }
        if (current == State.Approached)
        {
            approachDelay -= Time.deltaTime;

            if (currentLine == 58 && approachDelay <= 0f)
                NextLine(7.3f);
            else if(currentLine == 59 && approachDelay <= 0f)
                NextLine(2.5f);
            else if (currentLine == 60 && approachDelay <= 0f)
                NextLine(6.0f);
            else if (currentLine <= 61 && approachDelay <= 0f)
                NextLine(4.0f);
        }

        if (CH1_Heart.warm && current == State.Approached)
        {
            currentLine = 62;
            current = State.Warm;
        }
        else if (CH1_Heart.cold && current == State.Approached)
        {
            currentLine = 65;
            current = State.Cold;
        }
        if (current == State.Warm)
        {
            PlayerPrefs.SetInt("Warm/Cold", 1);
            warmDelay -= Time.deltaTime;

            if (currentLine <= 64 && warmDelay <= 0f)
                NextLine(5.0f);
        }
        if (current == State.Cold)
        {
            PlayerPrefs.SetInt("Warm/Cold", 2);
            coldDelay -= Time.deltaTime;

            if (currentLine == 65 && coldDelay <= 0f)
                NextLine(5.0f);
            else if (currentLine <= 68 && coldDelay <= 0f)
                NextLine(4.0f);
        }

        if (currentLine == 65 || currentLine == 69)
        {
            if (outroDelay > 0f)
                outroDelay -= Time.deltaTime;
            else if (outroDelay <= 0f)
            {
                SceneManager.LoadScene("Chapter_2");
            }
        }
    }

    void NextLine(float delay)
    {
        textType.UpdateLine();
        currentLine++;
        if (current == State.Abandonded)
            abandonDelay = delay;
        else if (current == State.Approached)
            approachDelay = delay;
        else if (current == State.Warm)
            warmDelay = delay;
        else if (current == State.Cold)
            coldDelay = delay;
    }
}

