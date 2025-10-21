using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseMeetingUI : MonoBehaviour
{
    public Button closeBtn;
    public Button meetBtn;
    public Button joinBtn;

    public GameObject choosePanel;
    public GameObject joinPanel;

    public GameObject loginPanel;

    void Start()
    {
        closeBtn.onClick.AddListener(ClosePanel);
        meetBtn.onClick.AddListener(OpenMeet);
        joinBtn.onClick.AddListener(OpenJoin);
    }

    void ClosePanel()
    {
        gameObject.SetActive(false);
        loginPanel.SetActive(true);
    }
    void OpenMeet()
    {
        gameObject.SetActive(false);
        choosePanel.SetActive(true);
    }
    void OpenJoin()
    {
        joinPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
