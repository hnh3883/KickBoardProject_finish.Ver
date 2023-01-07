using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash_Point : MonoBehaviour
{
    public static bool CarStart = false; 
    public GameObject cube;
    public GameObject cube1;
    public GameObject cube2;
    public GameObject cube3;

    void Start()
    {
        CarStart = false;
        cube.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        cube3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CarStart = true;
            cube.SetActive(true);
            cube1.SetActive(true); 
            cube2.SetActive(true);
            cube3.SetActive(true);
        }
    }
}
