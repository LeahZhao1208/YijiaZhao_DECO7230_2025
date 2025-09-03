using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
    public DebugRotator targetRotator;

    public Button toggleButton;
    public Button speedUpButton;
    public Button speedDownButton;
    public Button changeColorButton;

    [Header("Speed Settings")]
    [SerializeField] float delta = 20f;
    [SerializeField] float minSpeed = 0f;
    [SerializeField] float maxSpeed = 360f;

    [Header("Color Transition")]
    [SerializeField] float transitionDuration = 0.4f; // 渐变时长（秒）
    [SerializeField] Color[] colors = { Color.red, Color.green, Color.blue, Color.yellow, Color.white };

    Renderer cubeRenderer;
    Material cubeMaterial;        // 独立实例，避免改到共享材质
    int currentColorIndex = 0;
    Coroutine colorRoutine;

    void Start()
    {
        if (toggleButton)    toggleButton.onClick.AddListener(ToggleRotation);
        if (speedUpButton)   speedUpButton.onClick.AddListener(SpeedUp);
        if (speedDownButton) speedDownButton.onClick.AddListener(SpeedDown);
        if (changeColorButton) changeColorButton.onClick.AddListener(ChangeColor);

        if (targetRotator)
        {
            cubeRenderer = targetRotator.GetComponent<Renderer>();
            if (cubeRenderer != null)
            {
                // .material 会为该Renderer创建材质实例，便于单独修改颜色
                cubeMaterial = cubeRenderer.material;
                // 初始化为颜色数组的第一个，避免第一次跳变过大
                cubeMaterial.color = colors[currentColorIndex];
            }
        }
    }

    void ToggleRotation()
    {
        if (!targetRotator) return;
        targetRotator.isRotating = !targetRotator.isRotating;
    }

    void SpeedUp()
    {
        if (!targetRotator) return;
        targetRotator.rotationSpeed = Mathf.Clamp(targetRotator.rotationSpeed + delta, minSpeed, maxSpeed);
    }

    void SpeedDown()
    {
        if (!targetRotator) return;
        targetRotator.rotationSpeed = Mathf.Clamp(targetRotator.rotationSpeed - delta, minSpeed, maxSpeed);
    }

    void ChangeColor()
    {
        if (cubeMaterial == null) return;

        // 计算下一个目标颜色
        int nextIndex = (currentColorIndex + 1) % colors.Length;
        Color targetColor = colors[nextIndex];

        // 如果正在渐变，先停掉
        if (colorRoutine != null) StopCoroutine(colorRoutine);
        colorRoutine = StartCoroutine(LerpColor(cubeMaterial.color, targetColor, transitionDuration));

        currentColorIndex = nextIndex;
    }

    IEnumerator LerpColor(Color from, Color to, float duration)
    {
        if (duration <= 0f)
        {
            cubeMaterial.color = to;
            yield break;
        }

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / duration;
            // 这里可换成缓动函数：如 t*t*(3-2*t) 让过渡更顺滑
            float eased = t * t * (3f - 2f * t);
            cubeMaterial.color = Color.LerpUnclamped(from, to, eased);
            yield return null;
        }
        cubeMaterial.color = to;
        colorRoutine = null;
    }
}
