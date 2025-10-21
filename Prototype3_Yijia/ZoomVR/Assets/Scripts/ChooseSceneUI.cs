using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChooseSceneUI : MonoBehaviour
{
    public Button closeBtn;
    public GameObject ChooseMeetingUI;
    public GameObject meetRoom;
    public Button meetroomBtn;
    public Button mode3droomBtn;
    public MeetRoomPanel MeetRoomPanel;
    public GameObject mode2Dmain;
    public GameObject mode3Dmain;
    public GameObject exit3dMainBtn;
    public GameObject modelBtn;
    void Start()
    {
        closeBtn.onClick.AddListener(ClosePanel);
        meetroomBtn.onClick.AddListener(OpenMeetRoom);
        mode3droomBtn.onClick.AddListener(OpenCubeRoom);
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
    void OpenMeetRoom()
    {
        gameObject.SetActive(false);
        meetRoom.SetActive(true);
        mode2Dmain.SetActive(true);
    }
    void OpenCubeRoom()
    {
        gameObject.SetActive(false);
        modelBtn.SetActive(true);
        mode3Dmain.SetActive(true);
        exit3dMainBtn.SetActive(true);
    }
}
