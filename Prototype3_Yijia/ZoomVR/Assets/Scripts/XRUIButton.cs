using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class XRUIButton : MonoBehaviour
{
    private Button button;
    public GameObject ZoomPanel;
    void Start()
    {
        button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnUIButtonClicked);
        }
    }

    void OnUIButtonClicked()
    {
        Debug.Log($"UI 按钮被点击: {gameObject.name}");
        ZoomPanel.SetActive(true);
        gameObject.SetActive(false);

        // 在这里添加点击后的逻辑
    }
}
