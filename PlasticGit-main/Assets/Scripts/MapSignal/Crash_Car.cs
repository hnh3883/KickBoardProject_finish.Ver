using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crash_Car : MonoBehaviour
{
    Vector3 move = new Vector3(0, 0, 1);
    [SerializeField] int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        move = new Vector3(0, 0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("update");
        if (Crash_Point.CarStart == true)
        {
            transform.Translate(move * Time.deltaTime, Space.Self);
            // Debug.Log("trans");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CrashPoint")
        {
            Crash_Point.CarStart = false;
            gameObject.SetActive(false);
        }
    }

}
