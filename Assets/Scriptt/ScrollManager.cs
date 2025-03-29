using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using System.Collections.Generic;

public class ScrollController : MonoBehaviour
{
    public ScrollRect scrollRect;
    public float scrollStep = 0.5f;
    public float scrollDuration  = 0.1f;
    public GameObject itemPrefab;
    public Transform contentHolder;
    public TextMeshProUGUI sumText;
    public Sprite addSprite,removeSprite;
    // public float scrollSpeed =5f;

    private int totalSum = 0; 
    private Dictionary<int, GameObject> addedItems = new Dictionary<int, GameObject>();
    private float targetPosition;


  public void OnButtonClick(int number)
    {
        Button button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        ToggleItem(number, button);
    }

    public void ToggleItem(int number, Button button)
    {
        if (addedItems.ContainsKey(number)) 
        {
            RemoveItem(number);
            button.image.sprite = addSprite;
            // button.GetComponentInChildren<TextMeshProUGUI>().text = "Add " + number;
        }
        else 
        {
            AddItem(number);
            button.image.sprite = removeSprite;
            // button.GetComponentInChildren<TextMeshProUGUI>().text = "Remove " + number; 
        }
    }

    void AddItem(int number)
    {
        if (addedItems.ContainsKey(number)) return;
        GameObject newItem = Instantiate(itemPrefab, contentHolder);
        newItem.transform.SetParent(contentHolder, false);

        TextMeshProUGUI numberText = newItem.transform.Find("NumberText").GetComponent<TextMeshProUGUI>();
        numberText.text = number.ToString();

        Button removeButton = newItem.transform.Find("RemoveButton").GetComponent<Button>();
        removeButton.onClick.AddListener(() => RemoveItem(number));

        addedItems[number] = newItem;
        totalSum += number;
        UpdateSum();
    }

    void RemoveItem(int number)
    {
        if (!addedItems.ContainsKey(number)) return;
        Destroy(addedItems[number]);
        addedItems.Remove(number);
        totalSum -= number;
        UpdateSum();
    }

    private void UpdateSum()
    {
        sumText.text = totalSum.ToString();
    }

    public void ScrollUp()
    {
        float newPos = Mathf.Clamp01(scrollRect.verticalNormalizedPosition + scrollStep);
        scrollRect.DOVerticalNormalizedPos(newPos, scrollDuration).SetEase(Ease.OutQuad);
    }

    public void ScrollDown()
    {
        float newPos = Mathf.Clamp01(scrollRect.verticalNormalizedPosition - scrollStep);
        scrollRect.DOVerticalNormalizedPos(newPos, scrollDuration).SetEase(Ease.OutQuad);
    }

    // void Start()
    // {
    //     targetPosition = scrollRect.verticalNormalizedPosition;    
    // }
    // void Update() 
    // {
    //     scrollRect.verticalNormalizedPosition = Mathf.Lerp(scrollRect.verticalNormalizedPosition,targetPosition,Time.deltaTime * scrollSpeed);
    // }
    // public void ScrollUp()
    // {
    //     targetPosition = Mathf.Clamp01(targetPosition + scrollStep);
    //     Debug.Log("Scroll Up: " + targetPosition);
    // }
    // public void ScrollDown()
    // {
    //     targetPosition = Mathf.Clamp01(targetPosition - scrollStep);
    //     Debug.Log("Scroll Down: " + targetPosition);
    // }
}
