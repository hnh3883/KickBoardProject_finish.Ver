using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class realTestKK : MonoBehaviour
{
    public static List<int> ShuffleList = new List<int>();
    List<int> IndexList = new List<int>();

    public static int ListIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            shuffle();

            for (int i = 0; i < IsToggle.NotShuffleList.Count; i++)
            {
                Debug.Log(i + " ,,   NotShuffleList  : " + IsToggle.NotShuffleList[i]);
            }
        }
    }

    public void shuffle()
    {
        for (int i = 0; i < IsToggle.NotShuffleList.Count; i++)    // NotShuffleList ��ŭ �ݺ��� ������ index ���� �����ð���
        {
            IndexList.Add(i);  // �ε��� �� ��������
            Debug.Log(i + " ,,   IndexList  : " + IndexList[i]);
        }


        for (int i = 0; i < IsToggle.NotShuffleList.Count; i++)  // NotShuffleList�� ���ڸ�ŭ �ݺ����� ����
        {
            int randomNum = Random.Range(0, IndexList.Count);  // �ε����� �����ȿ��� �������� ����
            ShuffleList.Add(IsToggle.NotShuffleList[IndexList[randomNum]]);  // IndexList �迭���� randomNum��°�� �� -> A��� ����
                                                                             // NotShuffleList �迭���� A��°�� ���� ShuffleList�� �־���

            Debug.Log(i + " ,,   ShuffleList  : " + ShuffleList[i]);
            IndexList.RemoveAt(randomNum);  // �迭�� �߰����ذ��� ���������ν� �ߺ��� ����

        }

        NextNext.LoadNextLevel();

    }
}
