using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLController : MonoBehaviour
{
    public GameObject target;
    public float offsetX;
    public float offsetY;
    public float offsetZ;

    void Update()
    {
        Vector3 FixedPos =
            new Vector3(
            target.transform.position.x + offsetX - 0.275f,
            target.transform.position.y + offsetY + 0.677f,
            target.transform.position.z + offsetZ-0.062f);
            transform.position = FixedPos;
    }
}
