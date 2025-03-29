using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audioSource; // Assign manually in Inspector

    void Start()
    {
        if (audioSource == null) // Check if AudioSource is missing
        {
            Debug.LogError("AudioSource is not assigned! Please assign it in the Inspector.");
        }

        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource is missing!");
        }
    }
}
