using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonSound : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    void Start()
    {
        //# This for one button
        // audioSource = gameObject.AddComponent<AudioSource>();
        // GetComponent<Button>().onClick.AddListener(() =>
        // {
        //     audioSource.PlayOneShot(clickSound);
        // });

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;

        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => PlayClickSound());
        }
    }
    void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
