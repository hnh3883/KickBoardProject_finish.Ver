using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsToggle : MonoBehaviour
{
/*    bool S_turn_1;
    bool S_turn_2;
    bool S_turn_3;
    bool Left_turn_1;
    bool Left_turn_2;
    bool Left_turn_3;
    bool Right_turn_1;
    bool Right_turn_2;
    bool Right_turn_3;
    bool U_turn_1;
    bool U_turn_2;
    bool U_turn_3;
    bool Constant;
    bool SpeedUP;
    bool SpeedDown;*/

    [SerializeField]
    private Toggle toggle;

    [SerializeField]
    int MySceneNum;

    public static List<int> NotShuffleList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        toggle = gameObject.GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CountMethod();
            Debug.Log(toggle.isOn);
        }

    }

    public void CountMethod()
    {
        if (toggle.isOn == true)
        {
            NotShuffleList.Add(MySceneNum);

        }
    }

}
