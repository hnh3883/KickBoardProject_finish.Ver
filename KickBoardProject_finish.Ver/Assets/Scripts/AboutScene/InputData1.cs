using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InputData1 : MonoBehaviour
{
    public InputField InputText_Name;
    public InputField InputText_Age;

    public static string name = null;
    public static string age = null;

    void Awake() 
    {
        name = InputText_Name.GetComponent<InputField>().text;
        age = InputText_Age.GetComponent<InputField>().text;    
    }

    // public void Start()
    // {
    //     PlayerPrefs.SetString("name",name);
    //     PlayerPrefs.SetString("age",age);
    //     PlayerPrefs.Save();

    //     Debug.Log(PlayerPrefs.GetString("name"));
    // }

    // Update is called once per frame
    void Update()
    {
        if (name.Length > 0 && Input.GetMouseButtonDown(0))
        {
            PlayerPrefs.SetString("name",name);
            Debug.Log('a');
        }
        
        if (age.Length > 0 && Input.GetMouseButtonDown(0))
        {
            PlayerPrefs.SetString("age",age);
        }
        PlayerPrefs.Save();
    }

}
