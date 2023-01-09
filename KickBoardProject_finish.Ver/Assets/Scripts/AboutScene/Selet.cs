using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class Selet : MonoBehaviour
{
    public Text playername;
    public Text playerage;
    public Text playerheight;
    public Text playerweight;

    // Start is called before the first frame update
    void Start()
    {
        DataManager.instance.DataClear();
    }

    // Update is called once per frame
    void Update()
    {
        DataManager.instance.nowplayer.name = playername.text;
        DataManager.instance.nowplayer.age = playerage.text;
        DataManager.instance.nowplayer.height = playerheight.text;
        DataManager.instance.nowplayer.weight = playerweight.text;

        DataManager.instance.SaveData();
    }
}
