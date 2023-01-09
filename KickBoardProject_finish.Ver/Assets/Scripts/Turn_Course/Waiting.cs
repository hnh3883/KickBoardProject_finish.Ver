using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiting : MonoBehaviour
{
    public static bool wait;
    AudioSource audio;
    GameObject start;

    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("Audio").GetComponent<AudioSource>();
        start = GameObject.Find("PlayCanvas/start!");

        start.SetActive(false);

        gameObject.GetComponent<Control2>().enabled = false;
        gameObject.GetComponent<scooterCtrl2>().enabled = false;
        wait = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audio.isPlaying)
        {
            start.SetActive(true);
            WaitScript();
            //Destroy(start,2f);
        }
    }

    void WaitScript()
    {
        gameObject.GetComponent<Control2>().enabled = true;
        gameObject.GetComponent<scooterCtrl2>().enabled = true;
        wait = true;
        Debug.Log("asdfasdf");
    }
}
