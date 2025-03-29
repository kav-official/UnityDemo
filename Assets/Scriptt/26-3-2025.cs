using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ActionTester : MonoBehaviour
{
    public Sprite normalSprite,clickedSprite;
    public TMP_Dropdown countrys;
    public TextMeshProUGUI textTotal;
    public TextMeshProUGUI textCountry,textTotalSccore;
    public Button[] buttons;
    public int[] buttonValue;
    
    [SerializeField] public GameObject itemPrefab;
    [SerializeField] public Transform contentPanel;

    private List<GameObject> itemList = new List<GameObject>(); 
    private Image[] buttonImages;
    private bool[] isClicked;
    private int totalValue = 0;

     public void CreateItem(int value)
    {
        GameObject newItem = Instantiate(itemPrefab, contentPanel); // สร้างไอเทมใหม่
        newItem.GetComponentInChildren<Text>().text = "Item: " + value; // ตั้งค่าข้อความในไอเทม

        // ใช้ GetComponentInChildren<Button>() เพื่อหาปุ่ม RemoveButton ในลูกของ GameObject
        Button removeButton = newItem.GetComponentInChildren<Button>();
        
        if (removeButton != null)
        {
            removeButton.onClick.AddListener(() => RemoveItem(newItem)); // เพิ่ม Listener
        }
        else
        {
            Debug.LogError("RemoveButton not found!");
        }

        itemList.Add(newItem); // เพิ่มไอเทมลงใน List
    }
    void RemoveItem(GameObject item)
    {
        itemList.Remove(item);
        Destroy(item); 
    }

    private void Start()
    {
        int buttonCount = buttons.Length;
        buttonImages = new Image[buttonCount];
        isClicked = new bool[buttonCount];

        for (var i = 0; i < buttonCount; i++)
        {
            buttonImages[i] = buttons[i].GetComponent<Image>();
            buttonImages[i].sprite = normalSprite;
            int index = i;
            buttons[i].onClick.AddListener(()=> onChangeSprite(index));
        }
        updatetotalPrice();
    }
    public void onChangeSprite(int index)
    {
        if(index < 0 || index >= buttonValue.Length) return;
        isClicked[index] = !isClicked[index];

        if(isClicked[index])
        {
            totalValue += buttonValue[index];
            buttonImages[index].sprite = clickedSprite;
        }else{
            totalValue -= buttonValue[index];
            buttonImages[index].sprite = normalSprite;
        }
        updatetotalPrice();
    }
    void updatetotalPrice()
    {
        textTotal.text = totalValue.ToString();
    }

    public void onCLickConfirm()
    {
        textTotalSccore.text = totalValue.ToString();
        textCountry.text = countrys.options[countrys.value].text;
    }
}
