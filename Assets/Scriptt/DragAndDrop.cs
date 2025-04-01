using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using System.Collections;
using TMPro;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject MessageWrong,MessageRight;
    public TextMeshProUGUI textFeeling;
    public string dragScor;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 originalPosition;

    [SerializeField] private string correctDropZoneTag;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // ลดความโปร่งใส
        canvasGroup.blocksRaycasts = false; // ปิดการชนเพื่อลากผ่านได้
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = Input.mousePosition; // อัปเดตตำแหน่งตามเมาส์
    }

    private int dropCount = 0;
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
         if (eventData.pointerEnter != null && eventData.pointerEnter.CompareTag(correctDropZoneTag))
        {
            dropCount++;
            
            textFeeling.text = dragScor;
            MessageRight.SetActive(true);
             StartCoroutine(HidAlert(1f));
            rectTransform.position = eventData.pointerEnter.transform.position; // วางให้อยู่ตรงกลาง DropZone
        }
        else
        {
            textFeeling.text = "";
            MessageWrong.SetActive(true);
            StartCoroutine(HidAlert(1f));
            rectTransform.position = originalPosition; // กลับไปที่เดิม
        }
    }
    
    private IEnumerator  HidAlert(float time)
    {
        yield return new WaitForSeconds(time);
        MessageWrong.SetActive(false);
        MessageRight.SetActive(false);
    }    
}
