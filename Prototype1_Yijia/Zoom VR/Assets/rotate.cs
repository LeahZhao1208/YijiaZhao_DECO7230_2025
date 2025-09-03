using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [Header("��ת����")]
    public float rotationSpeed = 5.0f; // ��ת�ٶ�
    public bool smoothRotation = true; // �Ƿ�ƽ����ת
    public float smoothFactor = 10.0f; // ƽ��ϵ��

    private Vector3 _previousMousePosition;
    private Vector3 _targetRotation;
    private bool _isRotating = false;

    void Update()
    {
        // �������������
        if (Input.GetMouseButtonDown(0))
        {
            _isRotating = true;
            _previousMousePosition = Input.mousePosition;
        }

        // ����������ͷ�
        if (Input.GetMouseButtonUp(0))
        {
            _isRotating = false;
        }

        // ���������ת����������ƶ�
        if (_isRotating)
        {
            // ��ȡ����ƶ���
            Vector3 mouseDelta = Input.mousePosition - _previousMousePosition;

            // ������ת�Ƕ�
            _targetRotation.y += mouseDelta.x * rotationSpeed * Time.deltaTime;
            _targetRotation.x -= mouseDelta.y * rotationSpeed * Time.deltaTime;

            // ������һ֡���λ��
            _previousMousePosition = Input.mousePosition;
        }

        // Ӧ����ת
        if (smoothRotation)
        {
            // ƽ����ת
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.Euler(_targetRotation),
                smoothFactor * Time.deltaTime
            );
        }
        else
        {
            // ֱ����ת
            transform.rotation = Quaternion.Euler(_targetRotation);
        }
    }

    // ������ת����R����
    void ResetRotation()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _targetRotation = Vector3.zero;
        }
    }
}
