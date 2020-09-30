using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{

    // Singleton initialization
    /*
    private static SkillManager instance;
    public static SkillManager Instance { get { return instance; } }

    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
    }

    public GameObject hotbar;
    [HideInInspector]
    public List<Action> actionInfo;
    [HideInInspector]
    public List<Button> actionButton;
    [HideInInspector]
    public bool onGCD;
    [HideInInspector]
    public float GCDRecast;

    private void Start() {
        actionInfo = hotbar.GetComponent<ActionArray>().action;
        onGCD = false;
        GCDRecast = actionInfo[0].recastTime;

        for (int i = 0; i < hotbar.transform.childCount; i++) {
            actionButton.Add(hotbar.transform.GetChild(i).GetComponent<Button>());
        }
        
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SkillButtonOnClick(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            SkillButtonOnClick(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            SkillButtonOnClick(2);
        }
    }

    private void SkillButtonOnClick(int index) {
        if (actionInfo[index].isGCD) {
            for (int i = 0; i < actionButton.Count; i++) {
                actionButton[i].onClick.Invoke();
            }
        }
    }*/















    /*[SerializeField]
    private Skill[] skill;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
   

    private void SkillButtonOnClick(int skillIndex)
    {
        if (skill[skillIndex].isGCD)
        {
            for (int i = 0; i < skill.Length; i++)
            {
                if (skill[i].isGCD)
                {
                    skill[i].button.onClick.Invoke();
                }
            }
        }
    }

    public void StartGCDCooldown()
    {
        
        for (int i = 0; i < skill.Length; i++)
        {
            if (skill[i].isGCD)
            {
                skill[i].button.onClick.Invoke();
            }
        }
    }*/
}


