using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TC_signal : MonoBehaviour
{
    public static bool TC1;
    public static bool TC2;
    public static bool TC3;
    public static bool TC4;
    [SerializeField] public string WhatCourse;

    // Start is called before the first frame update
    void Start()
    {
        TC1 = false;
        TC2 = false;
        TC3 = false;
        TC4 = false;

    }

    private void OnTriggerEnter(Collider other)
    { 
        // player �±׸� ���� ������Ʈ�� �ε����ٸ�
        if (other.gameObject.tag == "Player")
        {
            // ������ ���������� ����
            // (�׳� �ð��� ȿ��)
            GetComponent<MeshRenderer>().material.color = Color.red;

            // left ��ȣ�̸� Signal_Left�� true�� ��ȯ
            if (WhatCourse == "TC1")
            {
                TC1 = true;
            }
            if (WhatCourse == "TC2")
            {
                TC2 = true;
            }
            if (WhatCourse == "TC3")
            {
                TC3 = true;
            }
            if (WhatCourse == "TC4")
            {
                TC4 = true;
            }

        }
    }
}
