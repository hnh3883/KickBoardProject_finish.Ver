using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TC_Audio : MonoBehaviour
{
    AudioSource audioSource;

    // 오디오 클립
    [SerializeField] AudioClip SignalAudio1;  // 좌회전
    [SerializeField] AudioClip SignalAudio2;  // 우회전
    [SerializeField] AudioClip SignalAudio3;  // 직진
    [SerializeField] AudioClip SignalAudio4;  // U턴

    void Start()
    {
        // 오디오소스 컴포넌트
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TC_signal.TC1 == true)
        {
            audioSource.PlayOneShot(SignalAudio1);
            TC_signal.TC1 = false;
        }
        else if (TC_signal.TC2 == true)
        {
            audioSource.PlayOneShot(SignalAudio2);
            TC_signal.TC2 = false;
        }
        else if (TC_signal.TC3 == true)
        {
            audioSource.PlayOneShot(SignalAudio3);
            TC_signal.TC3 = false;
        }
        else if (TC_signal.TC4 == true)
        {
            audioSource.PlayOneShot(SignalAudio4);
            TC_signal.TC4 = false;
        }
    }
}
