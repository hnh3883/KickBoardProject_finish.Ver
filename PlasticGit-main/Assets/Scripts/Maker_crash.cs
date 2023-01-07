using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maker_crash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "maker")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "maker")
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }
}
