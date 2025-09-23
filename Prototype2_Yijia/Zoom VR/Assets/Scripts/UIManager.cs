using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelMainMenu;     // Panel_MainMenu
    public GameObject panelNewMeeting;   // Panel_NewMeeting
    public GameObject panelJoinMeeting;  // Panel_JoinMeeting

    [Header("Feature Roots / Game Objects")]
    public GameObject gameObject1;       // 先当作 2D Model 或 Join 后进入的内容
    public GameObject gameObject2;       // 先当作 3D Model

    [Header("Options")]
    public bool hideUIWhenFeatureStarts = true; // 启动功能后是否隐藏所有面板

    void Awake()
    {
        // 启动：只显示主菜单，隐藏功能对象
        ShowMainMenu();
        HideFeatures();
    }

    /* ====== Panel 切换 ====== */

    public void ShowMainMenu()
    {
        HideAllPanels();
        if (panelMainMenu) panelMainMenu.SetActive(true);
    }

    public void GoNewMeeting()
    {
        HideAllPanels();
        if (panelNewMeeting) panelNewMeeting.SetActive(true);
    }

    public void GoJoinMeeting()
    {
        HideAllPanels();
        if (panelJoinMeeting) panelJoinMeeting.SetActive(true);
    }

    public void BackToMain()
    {
        ShowMainMenu();
    }

    /* ====== 功能启动（示意）====== */

    // Panel_NewMeeting → 点 2D model
    public void Start2DModel()
    {
        HideFeatures();
        if (gameObject1) gameObject1.SetActive(true);
        if (hideUIWhenFeatureStarts) HideAllPanels();
    }

    // Panel_NewMeeting → 点 3D model
    public void Start3DModel()
    {
        HideFeatures();
        if (gameObject2) gameObject2.SetActive(true);
        if (hideUIWhenFeatureStarts) HideAllPanels();
    }

    // Panel_JoinMeeting → 点 Join(Submit)
    // 简化版：不校验输入，直接进入 GameObject1
    public void JoinMeeting()
    {
        HideFeatures();
        if (gameObject1) gameObject1.SetActive(true);
        if (hideUIWhenFeatureStarts) HideAllPanels();
    }

    /* ====== 工具方法 ====== */

    private void HideAllPanels()
    {
        if (panelMainMenu) panelMainMenu.SetActive(false);
        if (panelNewMeeting) panelNewMeeting.SetActive(false);
        if (panelJoinMeeting) panelJoinMeeting.SetActive(false);
    }

    private void HideFeatures()
    {
        if (gameObject1) gameObject1.SetActive(false);
        if (gameObject2) gameObject2.SetActive(false);
    }
}
