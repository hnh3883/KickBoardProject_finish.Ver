using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextNext : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {

            LoadNextLevel();
        }
    }

    public static void LoadNextLevel()                                                        // 바로 다음 스테이지로 넘어가는 치트키
    {

        if (realTestKK.ListIndex >= realTestKK.ShuffleList.Count)
        {
            SceneManager.LoadScene(16); 
            realTestKK.ListIndex = 0;
            realTestKK.ShuffleList.RemoveAll(x => (x) >= 0);
        }
        else
        {
            SceneManager.LoadScene(realTestKK.ShuffleList[realTestKK.ListIndex]);                                 // 'nextSceneIndex' 번째 씬을 출력하라
            realTestKK.ListIndex += 1;
        }
        
        //SceneManager.LoadScene(realTestKK.ShuffleList[1]);
    }
}
