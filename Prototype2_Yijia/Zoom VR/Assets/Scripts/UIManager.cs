using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject panelMainMenu;
    public GameObject panelNewMeeting;
    public GameObject panelJoinMeeting;

    [Header("Feature Roots / Game Objects")]
    public GameObject gameObject1;   // Meeting/2D
    public GameObject gameObject2;   // Meeting/3D

    [Header("In-Game UI (Drawer Menu)")]
    public GameObject canvasGameUI;  // ← Canvas_GameUI（World Space, 在 XR Origin/Camera Offset 下）
    [Tooltip("可选：抽屉脚本。用于在退出时立即复位为收起状态。")]
    public RightSideDrawer drawer;   // ← DrawerRoot 上的脚本（可不填，但建议填）

    public bool hideUIWhenFeatureStarts = true;

    void Awake()
    {
        ShowMainMenu();
        HideFeatures();     // 会关掉 GameObjects 并隐藏 Canvas_GameUI
        SetGameUI(false);   // ← 初始隐藏抽屉菜单（多一道保险）
    }

    /* ====== Panel 切换 ====== */
    public void ShowMainMenu()
    {
        HideAllPanels();
        if (panelMainMenu) panelMainMenu.SetActive(true);
        SetGameUI(false); // 在主菜单不显示抽屉
    }

    public void GoNewMeeting()
    {
        HideAllPanels();
        if (panelNewMeeting) panelNewMeeting.SetActive(true);
        SetGameUI(false);
    }

    public void GoJoinMeeting()
    {
        HideAllPanels();
        if (panelJoinMeeting) panelJoinMeeting.SetActive(true);
        SetGameUI(false);
    }

    public void BackToMain()
    {
        // 任何返回主菜单的路径都先关闭功能 & 菜单
        HideFeatures();   // 内部会 ForceClosed + 关闭 Canvas_GameUI
        ShowMainMenu();
    }

    /* ====== 功能启动 ====== */
    public void Start2DModel()
    {
        HideFeatures();
        if (gameObject1) gameObject1.SetActive(true);
        if (hideUIWhenFeatureStarts) HideAllPanels();
        SetGameUI(true);  // 进入 Meeting 后显示抽屉（RightSideDrawer.OnEnable 会自动收起）
    }

    public void Start3DModel()
    {
        HideFeatures();
        if (gameObject2) gameObject2.SetActive(true);
        if (hideUIWhenFeatureStarts) HideAllPanels();
        SetGameUI(true);
    }

    // JoinMeeting 简化版：直接进入 gameObject1
    public void JoinMeeting()
    {
        HideFeatures();
        if (gameObject1) gameObject1.SetActive(true);
        if (hideUIWhenFeatureStarts) HideAllPanels();
        SetGameUI(true);
    }

    /* ====== 工具方法 ====== */
    void HideAllPanels()
    {
        if (panelMainMenu) panelMainMenu.SetActive(false);
        if (panelNewMeeting) panelNewMeeting.SetActive(false);
        if (panelJoinMeeting) panelJoinMeeting.SetActive(false);
    }

    void HideFeatures()
    {
        // 关闭所有功能对象
        if (gameObject1) gameObject1.SetActive(false);
        if (gameObject2) gameObject2.SetActive(false);

        // 把抽屉立即复位为“收起”
        if (drawer != null) drawer.ForceClosedImmediate();

        SetGameUI(false);
    }

    void SetGameUI(bool on)
    {
        if (canvasGameUI && canvasGameUI.activeSelf != on)
            canvasGameUI.SetActive(on); // 打开时会触发 RightSideDrawer.OnEnable() 再次强制收起
    }
}
