using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down_15KM : MonoBehaviour
{
    public GameObject KM;

    void Start()
    {
        KM.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {    
            KM.SetActive(true);
        }
    }
}
