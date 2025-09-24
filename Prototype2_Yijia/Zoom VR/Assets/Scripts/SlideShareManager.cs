using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideShareManager : MonoBehaviour
{
    [Header("UI Refs")]
    public GameObject shareCard;    
    public RawImage slideDisplay;   

    [Header("Slide")]
    public Texture slideTexture;    

    public void ShowSlide()
    {
        if (!slideDisplay || !slideTexture) return;

        if (shareCard) shareCard.SetActive(false);
        slideDisplay.texture = slideTexture;
        slideDisplay.gameObject.SetActive(true);
    }

    public void StopSharing()
    {
        if (shareCard) shareCard.SetActive(true);
        if (slideDisplay) slideDisplay.gameObject.SetActive(false);
    }
}
