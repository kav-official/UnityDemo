using UnityEngine;
using UnityEngine.UI;

public class ButtonAudios : MonoBehaviour
{
     public AudioSource audioSource;

    void Start()
    {
        if (audioSource == null) 
        {
            audioSource = GameObject.Find("SoundManager").GetComponent<AudioSource>();
        }

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource found! Make sure you have a SoundManager.");
        }

        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();  // Play the sound when button is clicked
        }
    }
}
