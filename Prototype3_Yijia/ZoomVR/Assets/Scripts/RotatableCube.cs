using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotatableCube : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Transform attachTransform;
    
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        // 创建 Attach Point
        GameObject attachPoint = new GameObject("AttachPoint");
        attachTransform = attachPoint.transform;
        attachTransform.SetParent(transform);
        attachTransform.localPosition = Vector3.zero; // 设置在物体中心
        
        // 设置 Attach Transform
        grabInteractable.attachTransform = attachTransform;
        
        // 订阅事件
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
        
        // 配置抓取设置
        grabInteractable.trackPosition = false; // 不跟踪位置
        grabInteractable.trackRotation = true;  // 只跟踪旋转
        grabInteractable.throwOnDetach = false; // 释放时不抛出
    }
    
    private void OnGrab(SelectEnterEventArgs args)
    {
        // 抓取时保持当前位置
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }
    }
    
    private void OnRelease(SelectExitEventArgs args)
    {
        // 释放时恢复物理
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }
    }
}