using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal_Sound : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip SignalAudio1;  
    [SerializeField] AudioClip SignalAudio2;  
    [SerializeField] AudioClip SignalAudio3;  
    [SerializeField] AudioClip SignalAudio4;  

    [SerializeField] public GameObject UI_imageAndText1;  
    [SerializeField] public GameObject UI_imageAndText2;  
    [SerializeField] public GameObject UI_imageAndText3;  
    [SerializeField] public GameObject UI_imageAndText4;  

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        UI_imageAndText1.SetActive(false);
        UI_imageAndText2.SetActive(false);
        UI_imageAndText3.SetActive(false);
        UI_imageAndText4.SetActive(false);
    }

    void Update()
    {
        if (Signal.Signal_Left == true)
        {
            UI_imageAndText1.SetActive(true);
            audioSource.PlayOneShot(SignalAudio1);
            Signal.Signal_Left = false;
            Debug.Log("l2");
            Invoke("ImageOff", 5f);
        }
        else if (Signal.Signal_Right == true)
        {
            UI_imageAndText2.SetActive(true);
            audioSource.PlayOneShot(SignalAudio2);
            Signal.Signal_Right = false;
            Debug.Log("r2");
            Invoke("ImageOff", 5f);
        }
        else if(Signal.Signal_Straight == true)
        {
            UI_imageAndText3.SetActive(true);
            audioSource.PlayOneShot(SignalAudio3);
            Signal.Signal_Straight = false;
            Debug.Log("s2");
            Invoke("ImageOff", 5f);
        }
        else if(Signal.Signal_Uturn == true)
        {
            UI_imageAndText4.SetActive(true);
            audioSource.PlayOneShot(SignalAudio4);
            Signal.Signal_Uturn = false;
            Debug.Log("u2");
            Invoke("ImageOff", 5f);
        }
    }

    void ImageOff()
    {
        UI_imageAndText1.SetActive(false);
        UI_imageAndText2.SetActive(false);
        UI_imageAndText3.SetActive(false);
        UI_imageAndText4.SetActive(false);
    }
}
