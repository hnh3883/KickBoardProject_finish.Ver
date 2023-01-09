using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorrectLine1 : MonoBehaviour
{
    [SerializeField] public GameObject emergency;

    void Start()
    {
        emergency.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Road")
        {
            emergency.SetActive(false);
        }

        else
        {
            emergency.SetActive(true);
        }
    }
}
