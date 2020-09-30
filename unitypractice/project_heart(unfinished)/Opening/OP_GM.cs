using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OP_GM: MonoBehaviour
{
    enum State
    {
        Opening,                                    // 0
        Introduction,                               // 1-2
        Outro,
    }

    public static int currentLine = 0;
    public OP_TextType textType;
    public GameObject Heart;

    private State current = State.Opening;
    private float openingDelay = 3.5f;
    private float introDelay = 3.0f;
    private float outroDelay = 2.5f;

    public Animator Field_intro_anim;
    private bool playerIntroduced = false;

    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            textType.UpdateLine();
            currentLine++;
        }
    }*/

    void Update()
    {
        if (current == State.Opening)
        {
            openingDelay -= Time.deltaTime;
            if (openingDelay <= 0f)
            {
                textType.UpdateLine();
                currentLine++;
                current = State.Introduction;
            }
        }

        if (current == State.Introduction)
        {
            if (!Field_intro_anim.GetBool("Field_appear") && introDelay > 0f)
                introDelay -= Time.deltaTime;
            else if (!Field_intro_anim.GetBool("Field_appear") && introDelay <= 0f)
            {
                Field_intro_anim.SetBool("Field_appear", true);
                introDelay = 4.5f;
            }
            if (OP_Field_PlayerDetect.PlayerDetected && !playerIntroduced)       // Player is introduced, line 1
            {
                textType.UpdateLine();
                currentLine++;
                playerIntroduced = true;
            }
            if (playerIntroduced && introDelay < 2.5f && introDelay > 0f)
            {
                introDelay -= Time.deltaTime;
                Field_intro_anim.SetBool("Field_disappear", true);
            }
            else if (playerIntroduced && introDelay > 0f)
                introDelay -= Time.deltaTime;
            else if (playerIntroduced && introDelay <= 0f)                             // Show line 2
            {
                textType.UpdateLine();
                currentLine++;
                current++;
            }
        }

        if (current == State.Outro)
        {
            if (outroDelay > 0f)
                outroDelay -= Time.deltaTime;
            else if (outroDelay <= 0f)
                SceneManager.LoadScene("Chapter_1");
        }
    }
}
