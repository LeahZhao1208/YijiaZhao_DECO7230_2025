using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSwap : MonoBehaviour
{
    [Header("References")]
    public Toggle toggle;   
    public Image  icon;   

    [Header("Sprites")]
    public Sprite voiceOn;  
    public Sprite voiceMute; 
    void Awake()
    {
        if (!toggle) toggle = GetComponent<Toggle>();
        if (!icon)   icon   = GetComponentInChildren<Image>(true);

        Apply(toggle.isOn);                     
        toggle.onValueChanged.AddListener(Apply);
    }

    void OnDestroy() => toggle?.onValueChanged.RemoveListener(Apply);

    void Apply(bool isOn)
    {
        if (icon) icon.sprite = isOn ? voiceOn : voiceMute;
        // 以后接真实逻辑：AudioManager.Instance.SetMicEnabled(isOn);
    }
}
