using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 1. 데이터(코드 = 클래스)를 만들어야 함 => 저장된 데이터 생성
// 2. 그 데이터를 Json으로 변환(택배상자로 포장)
 
// 저장하는 방법
// 1. 저장할 데이터가 존재 
// 2. 데이터를 제이슨으로 변환
// 3. 제이슨을 외부에 저장

// 불러오는 방법
// 1. 외부에 저장된 제이슨을 가져옴
// 2. 제이슨을 데이터형태로 변환
// 3. 불러온 데이터를 사용

public class PlayerData
{
    public string name;
    public string age; 
    public string height;
    public string weight;
}

public class DataManager : MonoBehaviour
{
    // 싱글톤
    public static DataManager instance;
    // 위 정보를 갖고 있는 객체가 생김  
    public PlayerData nowplayer = new PlayerData();

    string path;

    public void Awake() 
    {
        // 싱글톤
        if (instance == null)
        {
            instance = this;
        }    
        else if(instance != this)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.dataPath + "/Player" ;

    }

    void Start()
    {
        
    }

    public void SaveData()
    {
        // 2. Json으로 변환
        string data = JsonUtility.ToJson(nowplayer);
        // 문자를 전부 저장 
        File.WriteAllText(path, data);
    }

    public void LoadData()
    {
        // 데이터 불러오기
        string data = File.ReadAllText(path);
        // Json을 데이터로 변환 
        PlayerData nowplayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void DataClear()
    {
        nowplayer = new PlayerData();   
    }
}
