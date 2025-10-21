using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JoinPanel : MonoBehaviour
{
    public Button closeBtn;
    public Button goBtn;
    public Button voiceBtn;
    public InputField emailPut;
    public GameObject mode2Dmain;
    public GameObject voiceInputPanel;
    public GameObject meetRoom;
    public GameObject choosePanel;
    void Start()
    {
        closeBtn.onClick.AddListener(ClosePanel);
        goBtn.onClick.AddListener(OpenMeetRoom);
        voiceBtn.onClick.AddListener(OpenVoice);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ClosePanel()
    {
        gameObject.SetActive(false);
        choosePanel.SetActive(true);
    }
    void OpenMeetRoom()
    {
        
        gameObject.SetActive(false);
        mode2Dmain.SetActive(true);
        meetRoom.SetActive(true);
    }
    void OpenVoice()
    {
        voiceInputPanel.SetActive(true);
        Invoke("voiceComeBack", 3.0f);
    }
    void voiceComeBack()
    {
        emailPut.text = "example@email.com";
        voiceInputPanel.SetActive(false);
    }
}
