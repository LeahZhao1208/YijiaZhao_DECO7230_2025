using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightSideDrawer : MonoBehaviour
{
    [Header("References")]
    public RectTransform drawerPanel;   // Panel_Drawer（锚点/枢轴=TopRight (1,1)）
    public Button handleButton;         // Btn_Handle（外侧把手，始终可见）
    public Button closeButtonInside;    // Panel_Drawer 里的关闭按钮（形如“〈”），可选

    [Header("Motion")]
    [Tooltip("展开位置（通常 0）")]
    public float openX = 0f;
    [Tooltip("收起位置（=抽屉宽度，正数，完全藏到右侧）")]
    public float closedX = 360f;
    public float duration = 0.25f;
    public AnimationCurve ease = AnimationCurve.EaseInOut(0,0,1,1);

    public bool IsOpen { get; private set; }

    Coroutine anim;

    void Awake()
    {
        if (!drawerPanel) { Debug.LogError("[RightSideDrawer] drawerPanel 未绑定"); enabled = false; return; }

        if (handleButton) handleButton.onClick.AddListener(OpenFromHidden);
        if (closeButtonInside) closeButtonInside.onClick.AddListener(CloseToHidden);
    }

    // 每次启用时强制回到“收起”初始状态（确保重新进入时是收起）
    void OnEnable()
    {
        ForceClosedImmediate();
    }

    /// <summary>立即复位为“收起”：停止动画、抽屉面板隐藏、把手可见</summary>
    public void ForceClosedImmediate()
    {
        if (anim != null) { StopCoroutine(anim); anim = null; }
        SetX(closedX);
        if (drawerPanel) drawerPanel.gameObject.SetActive(false);
        if (handleButton) handleButton.gameObject.SetActive(true);
        IsOpen = false;
    }

    /// <summary>点击外侧把手：激活抽屉，从右侧滑入；并隐藏把手</summary>
    public void OpenFromHidden()
    {
        if (IsOpen) return;

        if (drawerPanel) {
            drawerPanel.gameObject.SetActive(true);
            SetX(closedX); // 起始在收起位
        }

        if (handleButton) handleButton.gameObject.SetActive(false);

        if (anim != null) StopCoroutine(anim);
        anim = StartCoroutine(AnimateTo(openX, () => { IsOpen = true; }));
    }

    /// <summary>点击抽屉内关闭按钮：滑回去，动画结束后隐藏抽屉并显示把手</summary>
    public void CloseToHidden()
    {
        if (!drawerPanel || !drawerPanel.gameObject.activeSelf) return;
        if (anim != null) StopCoroutine(anim);

        anim = StartCoroutine(AnimateTo(closedX, () =>
        {
            drawerPanel.gameObject.SetActive(false);
            if (handleButton) handleButton.gameObject.SetActive(true);
            IsOpen = false;
        }));
    }

    IEnumerator AnimateTo(float targetX, System.Action onDone = null)
    {
        float t = 0f;
        float startX = drawerPanel.anchoredPosition.x;

        while (t < 1f)
        {
            t += Time.unscaledDeltaTime / duration; // 不受暂停/时间缩放影响
            float x = Mathf.Lerp(startX, targetX, ease.Evaluate(t));
            SetX(x);
            yield return null;
        }
        SetX(targetX);
        onDone?.Invoke();
        anim = null;
    }

    void SetX(float x)
    {
        if (!drawerPanel) return;
        var p = drawerPanel.anchoredPosition;
        p.x = x;
        drawerPanel.anchoredPosition = p;
    }
}
