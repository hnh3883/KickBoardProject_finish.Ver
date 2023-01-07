using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class CSVPath1 : MonoBehaviour
{
    public List<float> Timer = new List<float>(); 
    public float Timer1;
    public float startTime;

    string filename = "";

    public static int count = 0;  
    Vector3 Crashposition; 
    Vector3 Crashposition1;

    int Brake_Count; // 브레이크 횟수

    public List<float> PositionX = new List<float>();  //킥보드의 x축 위치
    public List<float> PositionZ = new List<float>();   //킥보드의 Z축 위치
    public List<bool> Brake_counting = new List<bool>();  //브레이크 사용유무 (브레이크 밟으면 True)
    public List<float> Kick_Velocity = new List<float>();  // 킥보드 속도
    public List<float> Kick_SteerAngle = new List<float>();  // 조향각도
    public List<bool> deviance = new List<bool>();  // 경로이탈 횟수


    public List<float> CollisionPositionX = new List<float>();
    public List<float> CollisionPositionZ = new List<float>();
    public List<float> CollisionPositionY = new List<float>();
    public List<int> CollisionCounting = new List<int>();
    // public List<float> CollisionTime = new List<float>();

    int scene; 
    

    void Awake()
    {
        startTime = Time.time;
    }

    void Update()
    {
        
        scene = SceneManager.GetActiveScene().buildIndex;

        filename = Application.dataPath + "/" + DataManager.instance.nowplayer.name + "_" + DataManager.instance.nowplayer.age + "_" + DataManager.instance.nowplayer.height + "_" + DataManager.instance.nowplayer.weight + "_" + scene +"_file.csv";

        Timer1 = Time.time;

        Timer.Add(Timer1);

        Crashposition = this.gameObject.transform.position;

        PositionX.Add(Crashposition.x);
        PositionZ.Add(Crashposition.z);
        Brake_counting.Add(Control2.bHandBraked);
        Kick_Velocity.Add(Collision.vec_kmPerhour_float);
        Kick_SteerAngle.Add(Control2.public_steerAngle);
        deviance.Add(CorrectLine.deviance_bool);

        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     WriteCSV();
        //     Debug.Log("space2");
        // }

        if (SceneLoad.CSVtoggle == true || Input.GetKeyDown(KeyCode.W))
        {
            WriteCSV();
            Debug.Log("space2");
        }
        

    }

    public void OnCollisionEnter(UnityEngine.Collision collision)
    {
        count += 1;
        CollisionCounting.Add(count); 
        Debug.Log(count);

        Crashposition1 = this.gameObject.transform.position;

        CollisionPositionX.Add(Crashposition1.x);
        CollisionPositionY.Add(Crashposition1.y);
        CollisionPositionZ.Add(Crashposition1.z);

        Debug.Log("x : " + Crashposition1.x);
        Debug.Log("y : " + Crashposition1.y);
        Debug.Log("z : " + Crashposition1.z);

        //CollisionTime.Add(Time.time);
    }

    public void WriteCSV()
    {
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        
        TextWriter tw = new StreamWriter(filename, false);

        tw.WriteLine("Time, PositionX, PositionZ, PositionY, CollisionCounting, Braking, Velocity, SteerAngle, deviance");
        tw.Close();

        tw = new StreamWriter(filename, true);
        for (int i = 0; i < PositionX.Count; i++)
        {
            tw.WriteLine(Timer[i]-startTime + "," + PositionX[i] + "," + PositionZ[i] + "," +
                "." + "," + "." + "," + Brake_counting[i] + "," + Kick_Velocity[i] + "," + Kick_SteerAngle[i] + "," + deviance[i]);

            for (int j = 0; j < CollisionCounting.Count; j++)
            {
                if(PositionX[i] == CollisionPositionX[j] && PositionZ[i] == CollisionPositionZ[j])
                {
                    tw.WriteLine(Timer[i]-startTime + "," + PositionX[i] + "," + PositionZ[i] + "," +
                    CollisionPositionY[j] + "," + CollisionCounting[j] + "," + Brake_counting[j] + "," + Kick_Velocity[j]
                     + "," + Kick_SteerAngle[j] + "," + deviance[j]);
                }
            }
        }
        
        tw.Close();
    }
}
