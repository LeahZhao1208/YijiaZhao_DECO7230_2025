using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseSceneUIManager : MonoBehaviour
{
    public Button Meetingroom, roundtable, closebtn;
    public GameObject chooseSceneUI;
    public GameObject chooseUI;
    public GameObject meetingcamera;
    public GameObject MeetingroomUI;
    public GameObject Roundtablecamera;
    public GameObject RoundtableUI;
    public GameObject foldbtn;
    // Start is called before the first frame update
    void Start()
    {
        Meetingroom.onClick.AddListener(changemeeting);
        roundtable.onClick.AddListener(changeroundtable);
        closebtn.onClick.AddListener(resetall);
    }

    private void resetall()
    {
        chooseSceneUI.SetActive(false);
        chooseUI.SetActive(true);
    }

    private void changeroundtable()
    {
        Roundtablecamera.SetActive(true);
        RoundtableUI.SetActive(true);
        chooseSceneUI.SetActive(false);
        foldbtn.SetActive(true);
    }

    private void changemeeting()
    {
       meetingcamera.SetActive(true);
        chooseSceneUI.SetActive(false);
        MeetingroomUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
