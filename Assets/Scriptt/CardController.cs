using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardController : MonoBehaviour
{
    public Image cardImage;  
    public Sprite frontSprite,backSprite;
    private string cardValue;
    public TextMeshProUGUI showValue;
    private bool isFaceUp = false; 

    void Start()
    {
        // cardImage.sprite = backSprite; // เริ่มต้นให้การ์ดอยู่ด้านหลัง
    }
    public void SetCard(Sprite front,Sprite back,string value)
    {
        frontSprite = front;
        backSprite = back;
        cardValue = value;
        // dragSprite.sprite = frontSprite;
        cardImage.sprite = backSprite;
        
         DraggableCard draggable = GetComponent<DraggableCard>();
        if (draggable != null)
        {
            // draggable.dragSprite = frontSprite;
            draggable.cardValue = cardValue;
        }

    }
    public void FlipCard()
    {
        isFaceUp = !isFaceUp; // สลับสถานะคว่ำ/หงาย
        cardImage.sprite = isFaceUp ? frontSprite : backSprite;
    }
}
