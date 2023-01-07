using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip SignalAudio1;  

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Finish.First_finish == true)
        {
            audioSource.PlayOneShot(SignalAudio1);
            Finish.First_finish = false;
        }
    }
}
