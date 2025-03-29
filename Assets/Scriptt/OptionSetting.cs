using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;

public class OptionSetting : MonoBehaviour
{
        public Slider slider1,slider2,slider3,timerSlider;
        public TextMeshProUGUI textSound,textGrapich,textSFX,textIncrease;
        public TextMeshProUGUI textCounter;
        public Button okButton,buttonIncrease,buttonDecrease;
        private int numbers =1;
        public float countDownTime= 10f;
        public Image imageTestt,completeImage;
        public Sprite currentButtonImage;
        public Sprite normoreSprite,hoverSprite;

        public AudioSource audioSource;
        public AudioClip soundClip;

        public Image fillImage;
        public Color startColor = Color.green;
        public Color midColor = Color.yellow;
        public Color endColor = Color.red;
        private float colorChangeSpeed = 33f;

        public void Start()
        {
            imageTestt.sprite = normoreSprite;
            if(slider1 == null)
                slider1 = GameObject.Find("slider1").GetComponent<Slider>();
            if(slider2 == null)
                slider2 = GameObject.Find("slider2").GetComponent<Slider>();
            if(slider3 == null)
                slider3 = GameObject.Find("slider3").GetComponent<Slider>();

            if(okButton == null)
                okButton = GameObject.Find("okButton").GetComponent<Button>();
            okButton.onClick.AddListener(onCLickGetOptionValue);
        }

        public void onCLickGetOptionValue()
        {
            float _slider1 = slider1.value;
            float _slider2 = slider2.value;
            float _slider3 = slider3.value;

            textSound.text = "Sound setting is :"+_slider1.ToString("F2");
            textGrapich.text  = "Graphich setting is :"+_slider2.ToString("F2");
            textSFX.text     = "SFX setting is :"+_slider3.ToString("F2");
            textIncrease.text = numbers.ToString();
            
            Debug.Log("The Slider Value is :::"+_slider1.ToString("F2")+"And"+_slider2.ToString("F2")+"And"+_slider3.ToString("F2"));
        }
        
        public void onIncrease()
            {
                numbers +=1;
                textCounter.text = numbers.ToString();
                Debug.Log(numbers);
            }
        public void onDecrease()
            {
                
                if(numbers == 1){
                    numbers = 1;
                }
                if(numbers > 1){
                    numbers -=1;
                }
                textCounter.text = numbers.ToString();
                Debug.Log(numbers);
            }

        public void onMousePointer()
            {
                imageTestt.sprite = hoverSprite;
            }
        public void OnMouseExit()
            {
                imageTestt.sprite = normoreSprite;
            }

        public void StartSlider()
        {
            StartCoroutine(StartCountdown());
        }

        IEnumerator  StartCountdown()
        {
            float currentTime               = countDownTime;
                  timerSlider.maxValue   = countDownTime;
                  timerSlider.value          = countDownTime;
                  fillImage.color              = startColor;

        while(currentTime > 0) {
                yield return new WaitForSeconds(0.1f);
                currentTime -= 0.1f;
                timerSlider.value = currentTime;
                
            if (currentTime <= countDownTime * 0.3f)
                fillImage.color = Color.Lerp(fillImage.color, endColor, colorChangeSpeed * Time.deltaTime); // สีแดง
            else if (currentTime <= countDownTime * 0.6f)
                fillImage.color = Color.Lerp(fillImage.color, midColor, colorChangeSpeed * Time.deltaTime); // สีเหลือง
            else
                fillImage.color = Color.Lerp(fillImage.color, startColor, colorChangeSpeed * Time.deltaTime); // สีเขียว

            }
            onCountDownComplete();
        }
        private void onCountDownComplete()
        {
            StartCoroutine(showWiner(3f));
            Debug.Log("Time is override here");
        }
        IEnumerator showWiner(float duration)
        {
            completeImage.gameObject.SetActive(true);
            audioSource.PlayOneShot(soundClip);
            yield return new WaitForSeconds(duration);
            completeImage.gameObject.SetActive(false);

        }
}
