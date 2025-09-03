using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinMeetingUIManager : MonoBehaviour
{
    public Button keyboard1;
    public Button Joinbutton;
    public Button microphone;
    public GameObject microphoneUI1;
    public InputField inputfield;
    public GameObject chooseSceneUI;
    public GameObject LoginUI;
    public Button closebtn;
    public GameObject chooseUI;

    // Start is called before the first frame update
    void Start()
    {
        keyboard1.onClick.AddListener(buttonchangecolor);
        microphone.onClick.AddListener(microphoneUI);
        Joinbutton.onClick.AddListener(choosemeetingUI);
        closebtn.onClick.AddListener(resetall);

    }

    private void resetall()
    {
       LoginUI.SetActive(false);
        chooseUI.SetActive(true);
    }

    private void choosemeetingUI()
    {
        chooseSceneUI.SetActive(true);
        LoginUI.SetActive(false);

    }

    private void microphoneUI()
    {
        microphoneUI1.SetActive(true);
        inputfield.text = "123456789";
        Invoke("HideMicrophone", 3f);
        Joinbutton.GetComponent<Image>().color = new Color(0.5f, 0.7f, 1.0f);
    }

    private void buttonchangecolor()
    {
        Joinbutton.GetComponent<Image>().color = new Color(0.5f, 0.7f, 1.0f);
        inputfield.text = "123456789";
    }
    private void HideMicrophone()
    {
        microphoneUI1.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
