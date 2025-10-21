using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseSceneUI : MonoBehaviour
{
    public Button closeBtn;
    public GameObject ChooseMeetingUI;
    public Button meetroomBtn;
    public Button mode3droomBtn;
    void Start()
    {
        closeBtn.onClick.AddListener(ClosePanel);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ClosePanel()
    {
        gameObject.SetActive(false);
        ChooseMeetingUI.SetActive(true);

    }
    
}
