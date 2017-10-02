using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Photon;

public class LookAroundCode : Photon.MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 0F;
	
	public float minimumX = -360F;
	public float maximumX = 360F;
	
	float rotationX = 0F;
	
	private List<float> rotArrayX = new List<float>();
	float rotAverageX = 0F;	
	
	public float frameCounter = 20;
	
	Quaternion originalRotation;
	
	void Update (){}
	public void lookAround()
	{
       
		if (axes == RotationAxes.MouseXAndY)
		{			
			rotAverageX = 0f;

			rotationX += Input.GetAxis("Mouse X") * sensitivityX;

			rotArrayX.Add(rotationX);

			if (rotArrayX.Count >= frameCounter) {
				rotArrayX.RemoveAt(0);
			}

			for(int i = 0; i < rotArrayX.Count; i++) {
				rotAverageX += rotArrayX[i];
			}

			rotAverageX /= rotArrayX.Count;

			rotAverageX = ClampAngle (rotAverageX, minimumX, maximumX);

			Quaternion xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
			
			transform.localRotation = originalRotation * xQuaternion; //* yQuaternion;
		}
		else if (axes == RotationAxes.MouseX)
		{			
			rotAverageX = 0f;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rotationX += sensitivityX;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rotationX -= sensitivityX;
            }
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
			
			rotArrayX.Add(rotationX);
			
			if (rotArrayX.Count >= frameCounter) {
				rotArrayX.RemoveAt(0);
			}
			for(int i = 0; i < rotArrayX.Count; i++) {
				rotAverageX += rotArrayX[i];
			}
			rotAverageX /= rotArrayX.Count;
			
			rotAverageX = ClampAngle (rotAverageX, minimumX, maximumX);
			
			Quaternion xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;			
		}
	
	}

	void Awake ()
	{			
		PhotonNetwork.ConnectUsingSettings ("v4.2");
		PhotonNetwork.sendRate = 60;
		PhotonNetwork.sendRateOnSerialize = 60;
		originalRotation = transform.localRotation;
	}

	
	public static float ClampAngle (float angle, float min, float max)
	{
		angle = angle % 360;
		if ((angle >= -360F) && (angle <= 360F)) {
			if (angle < -360F) {
				angle += 360F;
			}
			if (angle > 360F) {
				angle -= 360F;
			}			
		}
		return Mathf.Clamp (angle, min, max);
	}
}