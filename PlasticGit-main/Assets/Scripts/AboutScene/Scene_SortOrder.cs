using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Scene_SortOrder : MonoBehaviour
{

    [SerializeField]
    private Toggle Course_Toggle;  // ���
    [SerializeField] 
    private Text Course_Text;  // �� ���� ������ ������ �ؽ�Ʈ

    [SerializeField]
    int SceneBuildNum;  // �ڽſ� �´� �� ��ȣ

    public static int currentSceneIndex ;

    public static List<int> SceneSort = new List<int>();  // �� ��ȣ�� ���������� ���� �迭
    static int[] SceneBuildNum_List = new int[] { 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100,100};  // �� ���� ����
    // ���� ��� 1����-2��, 2����-3��, 3����-1�� ���� üũ�� �ߴٸ�
    // SceneSort = {3,1,2}
    // SceneBuildNum_List = {2,3,1}

    private void Start()
    {
        currentSceneIndex = 0;
    }

    void Update()
    {
        // ����׷� �α� ������ �� Ȯ�ο�
        if (Input.GetKeyDown(KeyCode.P))
        {
            for (int i = 0; i < SceneSort.Count; i++)
            {
                Debug.Log(i + " :: " + SceneSort[i]);
            }

            for (int i = 0; i < SceneBuildNum_List.Length; i++)
            {
                Debug.Log(i + " ->-> " + SceneBuildNum_List[i]);
            }
        }

        // �ݺ����� ������ SceneBuildNum_List�� ������ �����
        for (int i = 0; i < SceneSort.Count; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                if (SceneSort[i] == j+1)
                {
                    SceneBuildNum_List[j] = i;

                }
            }
        }


        // toggle�� üũ�Ǿ��ִٸ�, SceneBuildNum_List �迭��(�� ���� ����)�� �ؽ�Ʈ�� ���
        if (Course_Toggle.isOn == true)
        {
            Course_Text.text = SceneBuildNum_List[SceneBuildNum-1].ToString();
        }

        // toggle�� üũ �Ǿ����� �ʴٸ�, �ؽ�Ʈ�� "-"�� ���
        if (Course_Toggle.isOn == false)
        {
            Course_Text.text = "-";
        }

    }


    public void OnChangeToggle()
    {
        // toggle�� üũ�Ǿ��ִٸ�, SceneSort�� �ش� �� ��ȣ�� �־���
        if (Course_Toggle.isOn == true) 
        { 
            SceneSort.Add(SceneBuildNum); 
        }

        // toggle�� üũ �Ǿ����� �ʴٸ�, SceneSort�� �ش� �� ��ȣ�� ����
        if (Course_Toggle.isOn == false) 
        {   SceneSort.Remove(SceneBuildNum); 
        }
    }


}
