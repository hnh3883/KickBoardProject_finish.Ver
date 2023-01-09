using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control2 : MonoBehaviour
{
	GameObject StartCanvas;
	public bool activeSelf;

	[SerializeField] Transform StartPoint;

	// 바퀴 방향조종을 위한 Transform 2개
	public Transform tireTransformF;
	public Transform tireTransformR;

	public WheelCollider colliderF1;
	public WheelCollider colliderF2;
	public WheelCollider colliderR1;

	// 바퀴 회전을 위한 Transform
	public Transform wheelTransformF;
	public Transform wheelTransformR;

	// 속도에 따라서 방향전환율을 다르게 적용하기 위한 준비
	public float highestSpeed = 500f;
	public float lowSpeedSteerAngle = 0.1f;
	public float highSpeedStreerAngle = 25f;

	// 감속량
	public float decSpeed = 7f;

	// 속도제한을 위한 변수들
	public float currentSpeed;
	public float rpm;
	public float maxSpeed = 500f;    // 전진 최고속도
	public float maxRevSpeed = 100f; // 후진 최고속도

	public int maxTorque = 50;

	private float prevSteerAngle;
	public static bool bHandBraked = false;

	private float lowStiffness = 0.2f;
	private float highStiffness = 1f;

	float GetGetAxis;

	// public Texture2D speedometerDial;
	// public Texture2D speedometerPointer;

	public static float public_steerAngle; // CSV 파일용

	private void Awake()
	{
		StartCanvas = GameObject.Find("StartCanvas");
		GetGetAxis = 0;
	}

	void Start()
	{
		GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -100f, 0); // 무게중심이 높으면 차가 쉽게 전복된다
	}

	void FixedUpdate()
	{
		/*		if (StartCanvas.activeSelf == false)
				{

				}*/
		Use();
		UpdateWheels();
		// HandleMotor();  
		// HandleSteering();   
		HandBrake();
		//SideSlip();
	}

	void Update()
	{
		// 앞바퀴 2개를 이동방향으로 향하기
		tireTransformF.Rotate(Vector3.up, colliderF2.steerAngle - prevSteerAngle, Space.World);
		prevSteerAngle = colliderF2.steerAngle;

		if (Input.GetKeyDown(KeyCode.R))
		{
			transform.position = new Vector3(StartPoint.position.x, transform.position.y, StartPoint.position.z);
			transform.rotation = StartPoint.rotation;
		}

	}

	void Use()
	{
		// 최고속도 제한
		// WheelCollider.rpm 전진:+, 후진:-

		rpm = 2 * 3.14f * colliderR1.radius * colliderR1.rpm * 60 / 300;
		currentSpeed = Collision.vec_kmPerhour_int;
		float direction = Input.GetAxis("Vertical"); //전진:0.1~1, 후진:-0.1~-1
													 //print ("direction:" + direction);
		float torque = maxTorque * direction;

		if (!bHandBraked && direction > 0 && currentSpeed < maxSpeed)
		{
			//print ("전진");
			colliderR1.motorTorque = torque;
		}
		else if (!bHandBraked && direction < 0 && Mathf.Abs(currentSpeed) < maxRevSpeed)
		{
			//print ("후진");
			colliderR1.motorTorque = torque;
		}
		else
		{
			colliderR1.motorTorque = 0;
		}


		// 전후진 키를 누르지 않으면 제동이 걸리도록 한다
		if (!Input.GetButton("Vertical"))
		{
			colliderR1.brakeTorque = decSpeed;
		}
		else
		{
			colliderR1.brakeTorque = 0;
		}

		// 속도에 따라 방향전환율을 달리 적용하기 위한 계산
		float speedFactor = GetComponent<Rigidbody>().velocity.magnitude / highestSpeed;
		/** Mathf.Lerp(from, to, t) : Linear Interpolation(선형보간)
		 * from:시작값, to:끝값, t:중간값(0.0 ~ 1.0)
		 * t가 0이면 from을 리턴, t가 1이면 to 를 리턴함, 0.5라면 from, to 의 중간값이 리턴됨
		*/
		float steerAngle = Mathf.Lerp(lowSpeedSteerAngle, highSpeedStreerAngle, 1 / speedFactor);
        //print ("steerAngle:" + steerAngle);
        // x*=y-> x = x*y

/*        if (GetGetAxis>=-0.5 & GetGetAxis<=0.5)
        {
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				GetGetAxis = GetGetAxis - 0.03f;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				GetGetAxis = GetGetAxis + 0.03f;
			}
		}

		steerAngle *= GetGetAxis ;*/
		steerAngle *= Input.GetAxis("Horizontal") / 2;
		public_steerAngle = steerAngle;

		//좌우 방향전환
		colliderF1.steerAngle = steerAngle;
		colliderF2.steerAngle = steerAngle;

		// 바퀴회전효과
		wheelTransformF.Rotate(-colliderF1.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
		wheelTransformF.Rotate(-colliderF2.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
		wheelTransformR.Rotate(-colliderR1.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
	}

	private void UpdateWheels()
	{
		// 자동으로 바퀴를 굴러가는 움직임을 구현하기 위해 추가 
		// UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
		UpdateSingleWheel(colliderR1, wheelTransformR);
	}

	private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
	{
		Vector3 pos;
		Quaternion rot;

		// 휠 콜라이더의 회전이나 방향전환 등의 정보를 추출 
		wheelCollider.GetWorldPose(out pos, out rot);
		wheelTransform.position = pos;
		wheelTransform.rotation = rot;
	}

	void HandBrake()
	{
		if (Input.GetButton("Jump"))
		{
			bHandBraked = true;
			colliderF1.brakeTorque = 500000;
			colliderF2.brakeTorque = 500000;


		}
		else
		{
			colliderF1.brakeTorque = 0;
			colliderF2.brakeTorque = 0;
			colliderR1.brakeTorque = 0;
			bHandBraked = false;

		}
	}

	void SideSlip()
	{
		// 앞바퀴 브레이크 적용시 뒷바퀴가 미끄러지도록 마찰력을 줄임
		// if (!Input.GetButton ("Vertical"))
		// {?         
		// 	WheelFrictionCurve wfc = new WheelFrictionCurve();
		// 	wfc.asymptoteSlip = colliderR.sidewaysFriction.asymptoteSlip;
		// 	wfc.asymptoteValue = colliderR.sidewaysFriction.asymptoteValue;
		// 	wfc.extremumSlip = colliderR.sidewaysFriction.extremumSlip;
		// 	wfc.extremumValue = colliderR.sidewaysFriction.extremumValue;
		// 	wfc.stiffness = 0.01f;
		// 	colliderR.sidewaysFriction = wfc;
		// 	colliderR.sidewaysFriction = wfc;	
		// 	} 
		// else 
		// {
		WheelFrictionCurve wfc = new WheelFrictionCurve();
		wfc.asymptoteSlip = colliderR1.sidewaysFriction.asymptoteSlip;
		wfc.asymptoteValue = colliderR1.sidewaysFriction.asymptoteValue;
		wfc.extremumSlip = colliderR1.sidewaysFriction.extremumSlip;
		wfc.extremumValue = colliderR1.sidewaysFriction.extremumValue;
		wfc.stiffness = 1f;
		colliderR1.sidewaysFriction = wfc;
		colliderR1.forwardFriction = wfc;
		// }  
	}
}