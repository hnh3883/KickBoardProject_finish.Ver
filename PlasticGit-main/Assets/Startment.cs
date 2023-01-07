using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startment : MonoBehaviour
{
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
        Destroy(gameObject);
        }
    }
}
