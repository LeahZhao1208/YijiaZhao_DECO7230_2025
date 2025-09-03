using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerUImanager : MonoBehaviour
{
    public Button closebtn, answerbtn;
    public GameObject user2questionbtn,answerUI;
    // Start is called before the first frame update
    void Start()
    {
        closebtn.onClick.AddListener(close);
        answerbtn.onClick.AddListener(answer);
    }

    private void answer()
    {

        Text textComponent = user2questionbtn.GetComponentInChildren<Text>();
        textComponent.text = "¡Ì";
        user2questionbtn.SetActive(true);
        answerUI.SetActive(false);
    }

    private void close()
    {
       user2questionbtn.SetActive(true);
        answerUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
