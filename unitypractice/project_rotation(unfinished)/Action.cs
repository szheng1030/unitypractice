using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Action", menuName = "Action")]
public class Action : ScriptableObject
{
    public new string name;

    public bool isGCD;
    public float castTime;
    public float recastTime;

    public int potency;
    public float comboIndex;
    public float comboPotency;

    public Sprite sprite;
}