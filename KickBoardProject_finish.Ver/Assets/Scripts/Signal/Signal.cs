using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    // bool Ÿ�� ���ڷ� �ε������� ��ȣ������ �뵵 
    public static bool Signal_Left ;
    public static bool Signal_Right;
    public static bool Signal_Straight;
    public static bool Signal_Uturn;

    [SerializeField] public string WhatSignal;

    void Start()
    {
        Signal_Left = false;
        Signal_Right = false;
        Signal_Straight = false;
        Signal_Uturn = false;
    }

    // �ε����� OnTriggerEnter �ߵ�
    private void OnTriggerEnter(Collider other)
    {
        // player �±׸� ���� ������Ʈ�� �ε����ٸ�
        if (other.gameObject.tag == "Player")
        {
            // ������ ���������� ����
            // (�׳� �ð��� ȿ��)
            GetComponent<MeshRenderer>().material.color = Color.red;

            // left ��ȣ�̸� Signal_Left�� true�� ��ȯ
            if (WhatSignal == "left")
            {
                Signal_Left = true;
                Debug.Log("l");
            }
            if (WhatSignal == "right")
            {
                Signal_Right = true;
                Debug.Log("r");
            }
            if (WhatSignal == "straight")
            {
                Signal_Straight = true;
                Debug.Log("s");
            }
            if (WhatSignal == "uturn")
            {
                Signal_Uturn = true;
                Debug.Log("u");
            }

        }
    }

}
