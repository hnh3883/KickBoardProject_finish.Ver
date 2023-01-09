using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Collision : MonoBehaviour
{
    public static int count = 0;
    public static float speed = 0f;
    [SerializeField] TextMesh DisplaySpeed;

    public static int vec_kmPerhour_int;
    public static float vec_kmPerhour_float;

    public Rigidbody rb;

    private void Awake() 
    {

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        DisplaySpeed.text = "0";
    }

    void FixedUpdate()
    {
        float vec = Mathf.Sqrt(rb.velocity.x * rb.velocity.x + rb.velocity.y * rb.velocity.y + rb.velocity.z * rb.velocity.z);
        vec_kmPerhour_float = (vec * 3600) / 1000;
        vec_kmPerhour_int = (int)vec_kmPerhour_float;
        DisplaySpeed.text = vec_kmPerhour_int.ToString();

    }

}
