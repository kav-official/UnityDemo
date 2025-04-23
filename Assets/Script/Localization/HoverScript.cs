using UnityEngine;
using UnityEngine.EventSystems;

public class SmoothHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Color normalColor = new Color(0.34f, 0.34f, 0.34f);
    private Color hoverColor = new Color(0.69f, 0.69f, 0.69f);  
    private float scaleAmount = 1.02f;
    private float smoothSpeed = 5f;
    private Vector3 originalScale;
    private Vector3 targetScale;
    private UnityEngine.UI.Graphic uiGraphic;
    private Color currentColor;
    private Color targetColor;
    void Awake()
    {
        uiGraphic = GetComponent<UnityEngine.UI.Graphic>();
        originalScale = transform.localScale;
        targetScale = originalScale;

        if (uiGraphic != null)
        {
            currentColor = uiGraphic.color;
            targetColor = currentColor;
        }
    }
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * smoothSpeed);
        //# Color animation
        if (uiGraphic != null)
        {
            uiGraphic.color = Color.Lerp(uiGraphic.color, targetColor, Time.deltaTime * smoothSpeed);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        targetScale = originalScale * scaleAmount;
        targetColor = hoverColor;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        targetScale = originalScale;
        targetColor = normalColor;
    }
}
