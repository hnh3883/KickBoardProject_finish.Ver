using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall_event : MonoBehaviour
{
    Rigidbody rgd;
    
    // Start is called before the first frame update
    void Start()
    {
        rgd = GetComponent<Rigidbody>();
        rgd.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Crash_Point.CarStart == true)
        {
            rgd.useGravity = true;
        }
    }

}
