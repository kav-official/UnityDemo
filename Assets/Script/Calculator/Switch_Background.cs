using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ButtonSwitcchc : MonoBehaviour
{
    public Image image,backGroundImage,backGroundDisplay;
    public Color colorOn = Color.white;
    public Color colorOff = new Color(0f,0f,1f,52f);
    public Sprite spriteOff;
    public Sprite spriteOn;
    private bool isToggle = false;
    private float speed = 5.0f;
    public void onCLickTosWitch()
    {
        isToggle = !isToggle;
        UpdateSprite();
    }
    void UpdateSprite()
    {
        image.sprite = isToggle ? spriteOn : spriteOff;
        backGroundImage.color = isToggle ? colorOn : colorOff;
        backGroundDisplay.color = isToggle ? new Color(0.1f, 0.5f, 0.8f) : new Color(42f, 7f, 0f, 25f);
    }
}
