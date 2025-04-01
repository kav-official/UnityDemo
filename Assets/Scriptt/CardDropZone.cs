using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DropZone : MonoBehaviour, IDropHandler
{
    public TextMeshProUGUI cardValueText; 
    // public Image  dropImage;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableCard droppedCard = eventData.pointerDrag.GetComponent<DraggableCard>();

        if (droppedCard != null)
        {
            droppedCard.transform.SetParent(transform); 
            droppedCard.transform.position = transform.position;
            cardValueText.text             = "Card: " + droppedCard.cardValue;
            // dropImage.sprite               = droppedCard.dragSprite;
        }
    }
}
