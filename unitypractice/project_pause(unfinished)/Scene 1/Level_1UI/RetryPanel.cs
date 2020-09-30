using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryPanel : MonoBehaviour
{
    public static GameObject retryPanel;

    private void Start()
    {
        retryPanel = gameObject;
        retryPanel.SetActive(false);
    }

}
