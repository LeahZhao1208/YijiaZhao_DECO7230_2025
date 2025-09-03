using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onmousedownquestion : MonoBehaviour
{
    private Color originalColor;
    private bool isClicked = false;
    public GameObject questionUI;

    // �޸�OnMouseDown����
    private void OnMouseDown()
    {
        questionUI.SetActive(true);

        // ����ԭʼ��ɫ������ǵ�һ�ε����
        if (!isClicked)
        {
            originalColor = GetComponent<Renderer>().material.color;
            isClicked = true;
        }

        // �ı�������ɫΪ��ɫ
        GetComponent<Renderer>().material.color = Color.green;
    }

    // �����Ҫ�ָ���ɫ����������������
    public void ResetColor()
    {
        if (isClicked)
        {
            GetComponent<Renderer>().material.color = originalColor;
            isClicked = false;
        }
    }
}
