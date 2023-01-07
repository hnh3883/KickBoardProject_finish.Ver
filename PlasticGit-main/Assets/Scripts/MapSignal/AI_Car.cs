using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AI_Car : MonoBehaviour
{
    Vector3 move = new Vector3(0, 0, 1);
    [SerializeField] float speed = 5;
    
    void Start()
    {
        move = new Vector3(0, 0, speed);
    }

    void Update()
    {
        transform.Translate(move * Time.deltaTime, Space.Self);
    }
}
