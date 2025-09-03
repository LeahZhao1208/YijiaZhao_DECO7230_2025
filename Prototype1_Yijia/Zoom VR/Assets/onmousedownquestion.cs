using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onmousedownquestion : MonoBehaviour
{
    private Color originalColor;
    private bool isClicked = false;
    public GameObject questionUI;

    // 修改OnMouseDown方法
    private void OnMouseDown()
    {
        questionUI.SetActive(true);

        // 保存原始颜色（如果是第一次点击）
        if (!isClicked)
        {
            originalColor = GetComponent<Renderer>().material.color;
            isClicked = true;
        }

        // 改变物体颜色为绿色
        GetComponent<Renderer>().material.color = Color.green;
    }

    // 如果需要恢复颜色，可以添加这个方法
    public void ResetColor()
    {
        if (isClicked)
        {
            GetComponent<Renderer>().material.color = originalColor;
            isClicked = false;
        }
    }
}
