using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeetRoomPanel : MonoBehaviour
{
    public Button handBtn;
    public GameObject hand;

    public Button sharescreenBtn;
    public Button shareModelBtn;
    public Button canStopBtn;
    public GameObject stopShareObj;
    public GameObject myscreen;
    public GameObject model;

    public Button exitBtn;
    public GameObject ChooseSceneUI;
    public GameObject mode2Dmain;
    void Start()
    {
        handBtn.onClick.AddListener(HandEvent);
        shareModelBtn.onClick.AddListener(ShareModel);
        sharescreenBtn.onClick.AddListener(ShareScreen);
        canStopBtn.onClick.AddListener(StopShare);
        exitBtn.onClick.AddListener(ClosePanel);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void HandEvent()
    {
        hand.SetActive(!hand.activeSelf);
    }
    void ShareScreen()
    {
        shareModelBtn.gameObject.SetActive(false);
        sharescreenBtn.gameObject.SetActive(false);
        myscreen.SetActive(true);
        canStopBtn.gameObject.SetActive(true);
    }
    void ShareModel()
    {
        sharescreenBtn.gameObject.SetActive(false);
        shareModelBtn.gameObject.SetActive(false);
        model.SetActive(true);
        canStopBtn.gameObject.SetActive(true);
    }
    void StopShare()
    {
        //shareModelBtn.gameObject.SetActive(true);
        sharescreenBtn.gameObject.SetActive(true);
        myscreen.SetActive(false);
        canStopBtn.gameObject.SetActive(false);
        //model.SetActive(false);
    }
    void ClosePanel()
    {
        mode2Dmain.SetActive(false);
        gameObject.SetActive(false);
        ChooseSceneUI.SetActive(true);
    }
}
