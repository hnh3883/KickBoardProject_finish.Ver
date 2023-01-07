using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TC_Audio : MonoBehaviour
{
    AudioSource audioSource;

    // ����� Ŭ��
    [SerializeField] AudioClip SignalAudio1;  // ��ȸ��
    [SerializeField] AudioClip SignalAudio2;  // ��ȸ��
    [SerializeField] AudioClip SignalAudio3;  // ����
    [SerializeField] AudioClip SignalAudio4;  // U��

    void Start()
    {
        // ������ҽ� ������Ʈ
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
