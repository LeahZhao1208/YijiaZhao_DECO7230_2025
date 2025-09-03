using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choicebutton : MonoBehaviour
{
    public Button button;
    public GameObject LoginUI;
    public GameObject ChoiceUI;
    private void Start()
    {
        button.onClick.AddListener(EnterLogin);
    }

    private void EnterLogin()
    {
       LoginUI.SetActive(true);
        ChoiceUI.SetActive(false);  
    }
}
