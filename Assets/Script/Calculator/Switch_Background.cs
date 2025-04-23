using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ButtonSwitcchc : MonoBehaviour
{
    public Image image,backGroundImage,backGroundDisplay;
    public Color colorOn = Color.white;
    public Color32 colorOff = new Color32(50,50,50,255);
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
        backGroundDisplay.color = isToggle ? new Color32(28,128,204,255) : new Color32(38,38,38,255);
    }
}
