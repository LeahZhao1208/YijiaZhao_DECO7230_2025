using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [Header("旋转设置")]
    public float rotationSpeed = 5.0f; // 旋转速度
    public bool smoothRotation = true; // 是否平滑旋转
    public float smoothFactor = 10.0f; // 平滑系数

    private Vector3 _previousMousePosition;
    private Vector3 _targetRotation;
    private bool _isRotating = false;

    void Update()
    {
        // 检测鼠标左键按下
        if (Input.GetMouseButtonDown(0))
        {
            _isRotating = true;
            _previousMousePosition = Input.mousePosition;
        }

        // 检测鼠标左键释放
        if (Input.GetMouseButtonUp(0))
        {
            _isRotating = false;
        }

        // 如果正在旋转，处理鼠标移动
        if (_isRotating)
        {
            // 获取鼠标移动量
            Vector3 mouseDelta = Input.mousePosition - _previousMousePosition;

            // 计算旋转角度
            _targetRotation.y += mouseDelta.x * rotationSpeed * Time.deltaTime;
            _targetRotation.x -= mouseDelta.y * rotationSpeed * Time.deltaTime;

            // 更新上一帧鼠标位置
            _previousMousePosition = Input.mousePosition;
        }

        // 应用旋转
        if (smoothRotation)
        {
            // 平滑旋转
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.Euler(_targetRotation),
                smoothFactor * Time.deltaTime
            );
        }
        else
        {
            // 直接旋转
            transform.rotation = Quaternion.Euler(_targetRotation);
        }
    }

    // 重置旋转（按R键）
    void ResetRotation()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _targetRotation = Vector3.zero;
        }
    }
}
