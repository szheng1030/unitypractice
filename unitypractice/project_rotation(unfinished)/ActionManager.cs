using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class ActionManager : MonoBehaviour
{

    // Singleton initialization
    private static ActionManager instance;
    public static ActionManager Instance { get { return instance; } }

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        }
        else {
            instance = this;
        }
    }


    // Create Event Handler
    public delegate void HotbarEventHandler(float timer, int index);
    public static event HotbarEventHandler onGCDDown;
    public static event HotbarEventHandler onOGCDDown;


    // Globals
    public static float GCDTimer;
    public static bool GCDstatus;


    // General initializations
    private GameObject hotbar;
    public static List<Action> actionInfo = new List<Action>();
    private Dictionary<KeyCode, int> keyToIndex = new Dictionary<KeyCode, int>();


    private void Start() {

        hotbar = GameObject.Find("Hotbar");
        defaultHotbarInit();

        for (int i = 0; i < hotbar.transform.childCount; i++) {
            actionInfo.Add(hotbar.GetComponent<ActionList>().actionList[i]);
        }
    }


    private void Update() {

        // Detect last key pressed down and stores in [lastKey]
        KeyCode lastKey = KeyCode.None;
        foreach (KeyCode kCode in Enum.GetValues(typeof(KeyCode))) {
            if (Input.GetKeyDown(kCode))
                lastKey = kCode;
        }


        // Call cooldown event based on which button pressed
        if (lastKey != KeyCode.None) {
            int targetIndex = keyToIndex[lastKey];
            Debug.Log(targetIndex);
            if (actionInfo[targetIndex].isGCD) {
                onGCDDown(actionInfo[targetIndex].recastTime, targetIndex);
            }
            else if (!actionInfo[targetIndex].isGCD) {
                onOGCDDown(actionInfo[targetIndex].recastTime, targetIndex);
            }
        }
    }


    // Default initializations of keybinds to hotbar indicies
    void defaultHotbarInit() {
        keyToIndex.Add(KeyCode.Alpha1, 0);
        keyToIndex.Add(KeyCode.Alpha2, 1);
        keyToIndex.Add(KeyCode.Alpha3, 2);
        keyToIndex.Add(KeyCode.Alpha4, 3);
        keyToIndex.Add(KeyCode.Alpha5, 4);
        keyToIndex.Add(KeyCode.Alpha6, 5);
        keyToIndex.Add(KeyCode.Alpha7, 6);
        keyToIndex.Add(KeyCode.Alpha8, 7);
        keyToIndex.Add(KeyCode.Alpha9, 8);
        keyToIndex.Add(KeyCode.Alpha0, 9);
    }
}
