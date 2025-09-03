using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class exit : MonoBehaviour
{
    public Button exitbtn;
    public GameObject meetingroomui;
    public GameObject choosemeetingui;
    public Button enterbtn;
    public Button enterbtn2;
    public GameObject menu;
    public Button Sharescreen;
    public GameObject Sharescreen2;
    public Button questionmarkbtn;
    public GameObject questionui;
    public Button keyboard;
    public Button closebtn;
    public Text questiontext;
    private Text originalButtonText;
    private Color originalButtonColor;
    private string originalText;
    private bool isGreen = false;
    public GameObject userquestion; // 在Inspector中拖拽赋值
    public Button userquestion2;
    public GameObject AnswerUI;
    public Button answerbtn;
    public Button closebtn2;
    public GameObject micUI;
    public Button micbtn;

    private void Start()
    {
        exitbtn.onClick.AddListener(returnchoosemeeting);
        enterbtn.onClick.AddListener(openmenu);
        enterbtn2.onClick.AddListener(closemenu);
        Sharescreen.onClick.AddListener(nosee);
        questionmarkbtn.onClick.AddListener(questionUI);
        keyboard.onClick.AddListener(keyboardview);
        closebtn.onClick.AddListener(closequestion);
        userquestion2.onClick.AddListener(answerUI);
        closebtn2.onClick.AddListener(closeanswerui);
        answerbtn.onClick.AddListener(answer);
        micbtn.onClick.AddListener(micview);
    }

    private void micview()
    {
        micUI.SetActive(true);
        Invoke("hidemic", 3f);
    }

    void hidemic()
    {
        questiontext.text = "&**&^*#*@$*^#@&…？";

        // 添加与keyboardview相同的效果
        // 保存原始状态
        if (!isGreen)
        {
            originalButtonText = questionmarkbtn.GetComponentInChildren<Text>();
            originalText = originalButtonText.text;
            originalButtonColor = questionmarkbtn.GetComponent<Image>().color;
        }

        // 修改按钮文字
        questionmarkbtn.GetComponentInChildren<Text>().text = "Submit";

        // 修改按钮颜色为浅绿色
        Color lightGreen = new Color(0.6f, 1.0f, 0.6f); // 浅绿色
        questionmarkbtn.GetComponent<Image>().color = lightGreen;

        isGreen = true;

        // 移除旧的监听器，添加新的监听器
        questionmarkbtn.onClick.RemoveAllListeners();
        questionmarkbtn.onClick.AddListener(OnGreenButtonClick);

        micUI.SetActive(false);
    }

    private void answer()
    {
        AnswerUI.SetActive(false);
        userquestion.SetActive(true);
        userquestion2.GetComponentInChildren<Text>().text = "√";
    }

    private void closeanswerui()
    {
        AnswerUI.SetActive(false);
        userquestion.SetActive(true);
    }

    private void answerUI()
    {
        AnswerUI.SetActive(true);
    }

    private void closequestion()
    {
        questionui.SetActive(false);
    }

    private void keyboardview()
    {
        questiontext.text = "&**&^*#*@$*^#@&…？";

        // 保存原始状态
        if (!isGreen)
        {
            originalButtonText = questionmarkbtn.GetComponentInChildren<Text>();
            originalText = originalButtonText.text;
            originalButtonColor = questionmarkbtn.GetComponent<Image>().color;
        }

        // 修改按钮文字
        questionmarkbtn.GetComponentInChildren<Text>().text = "Submit";

        // 修改按钮颜色为浅绿色
        Color lightGreen = new Color(0.6f, 1.0f, 0.6f); // 浅绿色
        questionmarkbtn.GetComponent<Image>().color = lightGreen;

        isGreen = true;

        // 移除旧的监听器，添加新的监听器
        questionmarkbtn.onClick.RemoveAllListeners();
        questionmarkbtn.onClick.AddListener(OnGreenButtonClick);
    }

    private void OnGreenButtonClick()
    {
        if (isGreen)
        {
            questionui.SetActive(false);
            // 显示userquestion
            if (userquestion != null)
            {
                userquestion.SetActive(true);
            }

            // 恢复按钮原始状态
            questionmarkbtn.GetComponentInChildren<Text>().text = originalText;
            questionmarkbtn.GetComponent<Image>().color = originalButtonColor;

            isGreen = false;

            // 恢复原来的监听器
            questionmarkbtn.onClick.RemoveAllListeners();
            questionmarkbtn.onClick.AddListener(questionUI);
        }
    }

    private void questionUI()
    {
        questionui.SetActive(true);
    }

    private void nosee()
    {
        Sharescreen2.SetActive(false);
    }

    private void closemenu()
    {
        menu.SetActive(false);
    }

    private void openmenu()
    {
        menu.SetActive(true);
    }

    private void returnchoosemeeting()
    {
        meetingroomui.SetActive(false);
        choosemeetingui.SetActive(true);
    }
}
