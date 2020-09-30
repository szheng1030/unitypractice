using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CooldownText : MonoBehaviour
{
    // Initializations
    private TextMeshProUGUI tmp;
    private float timer;


    void Start() {
        tmp = GetComponent<TextMeshProUGUI>();
    }


    // Update text with second remaining on CD
    void Update() {
        timer = (1.0f - GetComponentInParent<Image>().fillAmount) * 
            ActionManager.actionInfo[gameObject.transform.parent.GetSiblingIndex()].recastTime;

        if (timer > 0) {
            timer = (float)Math.Round((double)timer, 2);
            tmp.text = timer.ToString("0.0");
        }

        else {
            tmp.text = "";
        }
    }
}
