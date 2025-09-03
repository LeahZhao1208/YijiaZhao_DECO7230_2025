using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyboard : MonoBehaviour
{
    public Button keyboard1;
    public Button Nextbutton;
    public Button microphone;
    public GameObject microphoneUI1;
    public InputField inputfield;
    public GameObject choosemeetingUI1;
    public GameObject LoginUI;
    
    // Start is called before the first frame update
    void Start()
    {
        keyboard1.onClick.AddListener(buttonchangecolor);
        microphone.onClick.AddListener(microphoneUI);
        Nextbutton.onClick.AddListener(choosemeetingUI);
        
    }

    private void choosemeetingUI()
    {
        choosemeetingUI1.SetActive(true);
        LoginUI.SetActive(false);
        
    }

    private void microphoneUI()
    {
        microphoneUI1.SetActive(true);
        inputfield.text = "example@gmail.com";
        Invoke("HideMicrophone", 3f);
        Nextbutton.GetComponent<Image>().color = new Color(0.5f, 0.7f, 1.0f);
    }

    private void buttonchangecolor()
    {
        Nextbutton.GetComponent<Image>().color = new Color(0.5f, 0.7f, 1.0f);
        inputfield.text = "example@gmail.com";
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
