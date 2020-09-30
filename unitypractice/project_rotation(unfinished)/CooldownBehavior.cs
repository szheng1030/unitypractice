using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBehavior : MonoBehaviour {

    // Retrieve self index
    private int index;
    private void Awake() {
        index = gameObject.transform.GetSiblingIndex();
    }


    // Enable/Disable event triggers
    private void OnEnable() {
        if (index <= 2)
            ActionManager.onGCDDown += StartCooldown;
        else if (index >= 3)
            ActionManager.onOGCDDown += StartCooldown;
    }

    private void OnDisable() {
        if (index <= 2)
            ActionManager.onGCDDown -= StartCooldown;
        else if (index >= 3)
            ActionManager.onOGCDDown -= StartCooldown;
    }


    public Image image;
    private float cooldownTimer;
    private bool onCooldown = false;
    private bool onGCDQueue = false;
    private bool onOGCDQueue = false;


    private void StartCooldown(float timer, int _index) {

        if ((_index == 3 || _index == 4) && index != _index)
            return;

        if (!onCooldown) {
            cooldownTimer = timer;
            onCooldown = true;
            image.fillAmount = 0;
        }

        else if (onCooldown 
            && (timer - image.fillAmount * cooldownTimer) < 0.5
            && ActionManager.actionInfo[index].isGCD) {
            onGCDQueue = true;
        }
    }

    private void Update() {
        // Increase fill amount as timer progresses
        if (onCooldown) {
            image.fillAmount += 1 / cooldownTimer * Time.deltaTime;
        }

        // If cooldown finishes and a GCD is queued
        if (image.fillAmount >= 1 && onGCDQueue) {
            image.fillAmount = 0;
            onGCDQueue = false;
        }
        
        // If cooldon finishes and no GCDs are queued
        else if (image.fillAmount >= 1 && !onGCDQueue) {
            onCooldown = false;
        }
    }
}
