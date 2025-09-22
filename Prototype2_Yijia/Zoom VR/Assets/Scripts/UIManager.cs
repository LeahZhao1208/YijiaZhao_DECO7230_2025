using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gamePanel;
    public GameObject settingsPanel;

    void Start()
    {
        // 开始时只显示 StartPanel
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void ShowGame()
    {
        startPanel.SetActive(false);
        gamePanel.SetActive(true);
    }

    public void ShowSettings()
    {
        startPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToStart()
    {
        startPanel.SetActive(true);
        gamePanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
}
