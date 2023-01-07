using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_setactive : MonoBehaviour
{
    [SerializeField] public GameObject text1;  // U≈œ
    [SerializeField] public GameObject text2;  // U≈œ

    // Start is called before the first frame update
    void Start()
    {
        text2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Waiting.wait == true)
        {
            text1.SetActive(false);
            text2.SetActive(true);
        }
    }

}
