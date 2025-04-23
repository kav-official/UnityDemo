using UnityEngine;
using UnityEngine.UI;
public class SwitchSound : MonoBehaviour
{
    public AudioClip bgm;
    private AudioSource audioSource;
    public Image image;
    public Sprite spriteOff;
    public Sprite spriteOn;
    public Slider volumeSlider;
    private bool isToggle = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.loop = true;
        audioSource.playOnAwake = false;

        if (volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume; 
            volumeSlider.onValueChanged.AddListener(ChangeVolume);
        }
    }
    public void onClickSwitch()
    {
        isToggle = !isToggle;
        switchUI();
        switchPlayPause();
    }

    void switchUI()
    {
        image.sprite = isToggle ? spriteOn : spriteOff;
    }
    void switchPlayPause()
    {
        if (isToggle)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }
    }
    void ChangeVolume(float value)
    {
        audioSource.volume = value;
    }
}
