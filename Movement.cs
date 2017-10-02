using UnityEngine;
using Photon;
using System.Collections;

public class Movement : Photon.MonoBehaviour {
	public float speed1;
	private float lastSynchronizationTime = 0f;
	private float syncDelay = 0f;
	private float syncTime = 0f;
	private Vector3 syncEndPosition = Vector3.zero;
	private Quaternion syncEndRot = Quaternion.identity;
	private LookAroundCode look;
    private player2LookAroundCode look2;

	void Awake()
	{
		PhotonNetwork.ConnectUsingSettings ("v4.2");
		PhotonNetwork.sendRate = 60;
		PhotonNetwork.sendRateOnSerialize = 60;
	}

	void Start(){
		look = GetComponent<LookAroundCode> ();
        look2 = GetComponent<player2LookAroundCode>();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void movement(){
		transform.localPosition += transform.forward * speed1 * Time.deltaTime;
	}	
	
	void Update () {
		Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKey(KeyCode.UpArrow))
        {
			speed1=50;
		}
		if (speed1 >= 40 && speed1 <= 50) {
			speed1--;
		}
		if (this.photonView == null || this.photonView.observed != this)
		{
			Debug.LogWarning(this + " is not observed by this object's photonView! OnPhotonSerializeView() in this class won't be used.");
		}
       
		if (photonView.isMine) {
			movement ();
            look.lookAround();
		}

		else
		{
			transform.position = Vector3.Lerp(transform.position, transform.position, Time.deltaTime * 5);
			transform.rotation = Quaternion.Lerp(transform.rotation, transform.rotation, Time.deltaTime * 5);
		}

		if (transform.position.y <= -90) {
			Application.LoadLevel (0);
			PhotonNetwork.Disconnect ();
		}
	}
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		Vector3 playerPos=Vector3.zero;
		Quaternion playerRot=Quaternion.identity;
		if (stream.isWriting)
		{
			stream.SendNext (transform.position);
            stream.SendNext (transform.rotation);
		}
		else
		{
			this.syncEndPosition = (Vector3) stream.ReceiveNext ();
			this.syncEndRot = (Quaternion) stream.ReceiveNext ();
		}
		
	}
}
