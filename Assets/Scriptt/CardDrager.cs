using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform parentAfterDrag;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    public string cardValue;
    // public Sprite dragSprite;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false; 
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position; // อัปเดตตำแหน่งตามเมาส์
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        canvasGroup.blocksRaycasts = true;
    } 
}
