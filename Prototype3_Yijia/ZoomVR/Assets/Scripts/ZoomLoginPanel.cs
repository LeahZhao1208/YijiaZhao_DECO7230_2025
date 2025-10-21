using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ZoomLoginPanel : MonoBehaviour
{
    public Button closeBtn;
    public Button goBtn;
    public Button voiceBtn;
    public GameObject selectPanel;
    public InputField emailPut;
    public GameObject appIcon;
    public GameObject voiceInputPanel;
    void Start()
    {
        closeBtn.onClick.AddListener(ClosePanel);
        goBtn.onClick.AddListener(OpenSelect);
        voiceBtn.onClick.AddListener(OpenVoice);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ClosePanel()
    {
        gameObject.SetActive(false);
        appIcon.SetActive(true);
    }
    void OpenSelect()
    {
        gameObject.SetActive(false);
        selectPanel.SetActive(true);
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
