using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class user2btn : MonoBehaviour
{
    public Button button;
    public GameObject AnswerUI;
    public GameObject user2UI;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(answerUI);
    }

    private void answerUI()
    {
       AnswerUI.SetActive(true);
        user2UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
