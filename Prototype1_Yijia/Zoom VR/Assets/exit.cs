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
    public GameObject userquestion; // ��Inspector����ק��ֵ
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
        questiontext.text = "&**&^*#*@$*^#@&����";

        // �����keyboardview��ͬ��Ч��
        // ����ԭʼ״̬
        if (!isGreen)
        {
            originalButtonText = questionmarkbtn.GetComponentInChildren<Text>();
            originalText = originalButtonText.text;
            originalButtonColor = questionmarkbtn.GetComponent<Image>().color;
        }

        // �޸İ�ť����
        questionmarkbtn.GetComponentInChildren<Text>().text = "Submit";

        // �޸İ�ť��ɫΪǳ��ɫ
        Color lightGreen = new Color(0.6f, 1.0f, 0.6f); // ǳ��ɫ
        questionmarkbtn.GetComponent<Image>().color = lightGreen;

        isGreen = true;

        // �Ƴ��ɵļ�����������µļ�����
        questionmarkbtn.onClick.RemoveAllListeners();
        questionmarkbtn.onClick.AddListener(OnGreenButtonClick);

        micUI.SetActive(false);
    }

    private void answer()
    {
        AnswerUI.SetActive(false);
        userquestion.SetActive(true);
        userquestion2.GetComponentInChildren<Text>().text = "��";
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
        questiontext.text = "&**&^*#*@$*^#@&����";

        // ����ԭʼ״̬
        if (!isGreen)
        {
            originalButtonText = questionmarkbtn.GetComponentInChildren<Text>();
            originalText = originalButtonText.text;
            originalButtonColor = questionmarkbtn.GetComponent<Image>().color;
        }

        // �޸İ�ť����
        questionmarkbtn.GetComponentInChildren<Text>().text = "Submit";

        // �޸İ�ť��ɫΪǳ��ɫ
        Color lightGreen = new Color(0.6f, 1.0f, 0.6f); // ǳ��ɫ
        questionmarkbtn.GetComponent<Image>().color = lightGreen;

        isGreen = true;

        // �Ƴ��ɵļ�����������µļ�����
        questionmarkbtn.onClick.RemoveAllListeners();
        questionmarkbtn.onClick.AddListener(OnGreenButtonClick);
    }

    private void OnGreenButtonClick()
    {
        if (isGreen)
        {
            questionui.SetActive(false);
            // ��ʾuserquestion
            if (userquestion != null)
            {
                userquestion.SetActive(true);
            }

            // �ָ���ťԭʼ״̬
            questionmarkbtn.GetComponentInChildren<Text>().text = originalText;
            questionmarkbtn.GetComponent<Image>().color = originalButtonColor;

            isGreen = false;

            // �ָ�ԭ���ļ�����
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
