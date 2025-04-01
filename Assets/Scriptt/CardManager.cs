using UnityEngine;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab; 
    public Transform cardParent; 
    public Sprite[] cardFrontSprites; 
    public Sprite cardBackSprite; 
    public string[] cardValues;
    public int maxCards = 13;

    public void SpreadCrads()
    {
        CreateCards();
    }
    void CreateCards()
    {
         if (cardFrontSprites.Length != cardValues.Length)
        {
            Debug.LogError("จำนวนภาพไพ่ไม่ตรงกับจำนวนค่าการ์ด!");
            return;
        }

        List<int> indices = new List<int>();
        for (int i = 0; i < cardFrontSprites.Length; i++)
        {
            indices.Add(i); // เพิ่ม index ของไพ่ทั้งหมด
        }

        Shuffle(indices); // สุ่มลำดับไพ่

        int cardCount = Mathf.Min(maxCards, indices.Count); // จำกัดจำนวนการ์ดไม่เกิน 13 ใบ

        for (int i = 0; i < cardCount; i++)
        {
            int index = indices[i]; 
            GameObject newCard = Instantiate(cardPrefab, cardParent); 
            CardController cardController = newCard.GetComponent<CardController>(); 
            cardController.SetCard(cardFrontSprites[index], cardBackSprite, cardValues[index]); 
        }
    }

    void Shuffle(List<int> list)
    {
         for (int i = list.Count - 1; i > 0; i--)
    {
        int randomIndex = Random.Range(0, i + 1);
        int temp = list[i];
        list[i] = list[randomIndex];
        list[randomIndex] = temp;
    }
    }
}
