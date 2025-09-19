using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideOneShot : MonoBehaviour
{
    [Header("UI Refs")]
    public GameObject shareCard;    // ShareCard 面板
    public RawImage slideDisplay;   // SlideDisplay（RawImage）

    [Header("Slide")]
    public Texture slideTexture;    // 拖入你准备好的图片（png/jpg 导入后为 Texture2D）

    public void ShowSlide()
    {
        if (!slideDisplay || !slideTexture) return;

        // 隐藏上传卡片，显示幻灯片
        if (shareCard) shareCard.SetActive(false);
        slideDisplay.texture = slideTexture;
        slideDisplay.gameObject.SetActive(true);
    }
}

