using UnityEngine;

public class scooterCtrl2 : MonoBehaviour
{
    GameObject StartCanvas;
    public bool activeSelf;

    public Transform handleBar;
    public WheelCollider colliderF1;
    public WheelCollider colliderF2;


    public float highestSpeed = 500f;
	public float lowSpeedSteerAngle = 0.1f;
	public float highSpeedStreerAngle = 25f;

    private float prevSteerAngle;

    float GetGetAxis;

    private void Awake() 
    {
        StartCanvas = GameObject.Find("StartCanvas");
        GetGetAxis = 0;
    }

    void FixedUpdate()
    {
/*        if (StartCanvas.activeSelf == false)
        {

        } */           
        // 속도에 따라 방향전환율을 달리 적용하기 위한 계산
        float speedFactor = GetComponent<Rigidbody>().velocity.magnitude / highestSpeed;
        /** Mathf.Lerp(from, to, t) : Linear Interpolation(선형보간)
        * from:시작값, to:끝값, t:중간값(0.0 ~ 1.0)
        * t가 0이면 from을 리턴, t가 1이면 to 를 리턴함, 0.5라면 from, to 의 중간값이 리턴됨
        */
        float steerAngle = Mathf.Lerp(lowSpeedSteerAngle, highSpeedStreerAngle, 1 / speedFactor);
        //print ("steerAngle:" + steerAngle);
        // x*=y-> x = x*y

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (GetGetAxis >= -0.5)
            {
                GetGetAxis = GetGetAxis - 0.03f;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (GetGetAxis <= 0.5)
            {
                GetGetAxis = GetGetAxis + 0.03f;
            }
        }


        steerAngle *= GetGetAxis;

        //steerAngle *= Input.GetAxis("Horizontal") / 2;
        

        //좌우 방향전환
        colliderF1.steerAngle = steerAngle;
        colliderF2.steerAngle = steerAngle;
    }

    void Update() 
    {
		// 앞바퀴 2개를 이동방향으로 향하기
		handleBar.Rotate (Vector3.up, colliderF1.steerAngle-prevSteerAngle, Space.World);
		prevSteerAngle = colliderF1.steerAngle;
	}


    // [SerializeField]float delay = 1.0f;
    // private void Start()
    // {
    //     delay = Random.Range(0.0f, 1.0f);
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * delay);
    // }
}
