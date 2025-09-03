using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionUImangaer : MonoBehaviour
{
    public Button questionbtn;
    public GameObject question;
    public Button keyboard;
    public GameObject Submitbtn;
    public Button micbtn;
    public GameObject micUI;
    public Button Submitbtn2;
    public GameObject userquestion;
    public GameObject questionUI;
    public Button closebtn;
    public GameObject closeUI1;
    // Start is called before the first frame update
    void Start()
    {
        closebtn.onClick.AddListener(closeUI);
        keyboard.onClick.AddListener(keyboardview);
        questionbtn.onClick.AddListener(questionview);
        micbtn.onClick.AddListener(micview);
        Submitbtn2.onClick.AddListener(submitview);
        
    }

    private void closeUI()
    {
        closeUI1.SetActive(false);
    }

    private void submitview()
    {
        userquestion.SetActive(true);
        questionUI.SetActive(false);
        Submitbtn.SetActive(false);
        
    }

    private void micview()
    {
      micUI.SetActive(true);
        Invoke("hidemic", 3f);
        
    }

    private void keyboardview()
    {
        Submitbtn.SetActive(true);
        Text textComponent = question.GetComponentInChildren<Text>();
        textComponent.text = "&**&^*#*@$*^#@&бнг┐";
    }
    void hidemic()
    {
        Text textComponent = question.GetComponentInChildren<Text>();
        textComponent.text = "&**&^*#*@$*^#@&бнг┐";
        Submitbtn.SetActive(true);
        micUI?.SetActive(false);
    }

    private void questionview()
    {
        question.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
