using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public static bool First_finish = false;
    AudioSource audioSource; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        First_finish = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            this.audioSource.Play();
            First_finish = true;
        }
    }
}
