using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control2 : MonoBehaviour
{
	GameObject StartCanvas;
	public bool activeSelf;

	[SerializeField] Transform StartPoint;

	// ���� ���������� ���� Transform 2��
	public Transform tireTransformF;
	public Transform tireTransformR;

	public WheelCollider colliderF1;
	public WheelCollider colliderF2;
	public WheelCollider colliderR1;

	// ���� ȸ���� ���� Transform
	public Transform wheelTransformF;
	public Transform wheelTransformR;

	// �ӵ��� ���� ������ȯ���� �ٸ��� �����ϱ� ���� �غ�
	public float highestSpeed = 500f;
	public float lowSpeedSteerAngle = 0.1f;
	public float highSpeedStreerAngle = 25f;

	// ���ӷ�
	public float decSpeed = 7f;

	// �ӵ������� ���� ������
	public float currentSpeed;
	public float rpm;
	public float maxSpeed = 500f;    // ���� �ְ�ӵ�
	public float maxRevSpeed = 100f; // ���� �ְ�ӵ�

	public int maxTorque = 50;

	private float prevSteerAngle;
	public static bool bHandBraked = false;

	private float lowStiffness = 0.2f;
	private float highStiffness = 1f;

	float GetGetAxis;

	// public Texture2D speedometerDial;
	// public Texture2D speedometerPointer;

	public static float public_steerAngle; // CSV ���Ͽ�

	private void Awake()
	{
		StartCanvas = GameObject.Find("StartCanvas");
		GetGetAxis = 0;
	}

	void Start()
	{
		GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -100f, 0); // �����߽��� ������ ���� ���� �����ȴ�
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
		// �չ��� 2���� �̵��������� ���ϱ�
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
		// �ְ�ӵ� ����
		// WheelCollider.rpm ����:+, ����:-

		rpm = 2 * 3.14f * colliderR1.radius * colliderR1.rpm * 60 / 300;
		currentSpeed = Collision.vec_kmPerhour_int;
		float direction = Input.GetAxis("Vertical"); //����:0.1~1, ����:-0.1~-1
													 //print ("direction:" + direction);
		float torque = maxTorque * direction;

		if (!bHandBraked && direction > 0 && currentSpeed < maxSpeed)
		{
			//print ("����");
			colliderR1.motorTorque = torque;
		}
		else if (!bHandBraked && direction < 0 && Mathf.Abs(currentSpeed) < maxRevSpeed)
		{
			//print ("����");
			colliderR1.motorTorque = torque;
		}
		else
		{
			colliderR1.motorTorque = 0;
		}


		// ������ Ű�� ������ ������ ������ �ɸ����� �Ѵ�
		if (!Input.GetButton("Vertical"))
		{
			colliderR1.brakeTorque = decSpeed;
		}
		else
		{
			colliderR1.brakeTorque = 0;
		}

		// �ӵ��� ���� ������ȯ���� �޸� �����ϱ� ���� ���
		float speedFactor = GetComponent<Rigidbody>().velocity.magnitude / highestSpeed;
		/** Mathf.Lerp(from, to, t) : Linear Interpolation(��������)
		 * from:���۰�, to:����, t:�߰���(0.0 ~ 1.0)
		 * t�� 0�̸� from�� ����, t�� 1�̸� to �� ������, 0.5��� from, to �� �߰����� ���ϵ�
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

		//�¿� ������ȯ
		colliderF1.steerAngle = steerAngle;
		colliderF2.steerAngle = steerAngle;

		// ����ȸ��ȿ��
		wheelTransformF.Rotate(-colliderF1.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
		wheelTransformF.Rotate(-colliderF2.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
		wheelTransformR.Rotate(-colliderR1.rpm / 60 * 360 * Time.fixedDeltaTime, 0, 0);
	}

	private void UpdateWheels()
	{
		// �ڵ����� ������ �������� �������� �����ϱ� ���� �߰� 
		// UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
		UpdateSingleWheel(colliderR1, wheelTransformR);
	}

	private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
	{
		Vector3 pos;
		Quaternion rot;

		// �� �ݶ��̴��� ȸ���̳� ������ȯ ���� ������ ���� 
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
		// �չ��� �극��ũ ����� �޹����� �̲��������� �������� ����
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