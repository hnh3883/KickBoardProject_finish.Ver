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
        for (int i = 0; i < IsToggle.NotShuffleList.Count; i++)    // NotShuffleList 만큼 반복문 돌려서 index 값만 가져올것임
        {
            IndexList.Add(i);  // 인덱스 값 가져오기
            Debug.Log(i + " ,,   IndexList  : " + IndexList[i]);
        }


        for (int i = 0; i < IsToggle.NotShuffleList.Count; i++)  // NotShuffleList의 숫자만큼 반복문을 실행
        {
            int randomNum = Random.Range(0, IndexList.Count);  // 인덱스값 범위안에서 랜덤변수 생성
            ShuffleList.Add(IsToggle.NotShuffleList[IndexList[randomNum]]);  // IndexList 배열에서 randomNum번째의 값 -> A라고 하자
                                                                             // NotShuffleList 배열에서 A번째의 값을 ShuffleList에 넣어줌

            Debug.Log(i + " ,,   ShuffleList  : " + ShuffleList[i]);
            IndexList.RemoveAt(randomNum);  // 배열에 추가해준것은 삭제함으로써 중복을 막음

        }

        NextNext.LoadNextLevel();

    }
}
