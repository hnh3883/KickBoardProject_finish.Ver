using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public static bool CSVtoggle ; 

    private void Start()
    {
        CSVtoggle = false ;

        for (int i = 0; i < Scene_SortOrder.SceneSort.Count; i++)
        {
            Debug.Log(i + " :: " + Scene_SortOrder.SceneSort[i]);
        }
    }

    private void Update()
    {
        // �ٷ� ���� ���������� �Ѿ�� ġƮŰ
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CSVtoggle = true ;
            LoadNextLevel();
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        { 

            Application.Quit();
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().drag = 100000f;
            CSVtoggle = true ;
            StartCoroutine(LoadNextLevel1());
        }
    }

    IEnumerator LoadNextLevel1()                                                       
    {
        yield return new WaitForSeconds(1f);

        if (Scene_SortOrder.currentSceneIndex >= Scene_SortOrder.SceneSort.Count)
        {
            SceneManager.LoadScene(18);
            Scene_SortOrder.currentSceneIndex = 0;
        }
        else
        {
            SceneManager.LoadScene(Scene_SortOrder.SceneSort[Scene_SortOrder.currentSceneIndex]);    // 'nextSceneIndex' ��° ���� ����϶� 
            Scene_SortOrder.currentSceneIndex += 1;
        }
    }

    void LoadNextLevel()                                                       
    {
        if (Scene_SortOrder.currentSceneIndex >= Scene_SortOrder.SceneSort.Count)
        {
            SceneManager.LoadScene(18);
            Scene_SortOrder.currentSceneIndex = 0;
        }
        else
        {
            SceneManager.LoadScene(Scene_SortOrder.SceneSort[Scene_SortOrder.currentSceneIndex]);    // 'nextSceneIndex' ��° ���� ����϶� 
            Scene_SortOrder.currentSceneIndex += 1;
        }
    }

}
