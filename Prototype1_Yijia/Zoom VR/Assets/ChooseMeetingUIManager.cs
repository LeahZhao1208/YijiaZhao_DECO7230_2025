using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseMeetingUIManager : MonoBehaviour
{
    public Button closebtn;
    public Button joinbtn;
    public GameObject ChooseUI;
    public GameObject Loginmeeting;
    public GameObject JoinUI;
    // Start is called before the first frame update
    void Start()
    {
        closebtn.onClick.AddListener(restall);
        joinbtn.onClick.AddListener(LoginMeetingUI);
    }

    private void restall()
    {
       JoinUI.SetActive(false);
        ChooseUI.SetActive(true);

    }

    private void LoginMeetingUI()
    {
       Loginmeeting.SetActive(true);
        JoinUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
