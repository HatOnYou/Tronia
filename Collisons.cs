using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Photon;

public class Collisons : Photon.MonoBehaviour {
	float timer;
	public GameObject speedBoost;
	public GameObject currentPlayerPrefab;
	public Camera currentPlayerPrefabNormalCam;
	public GameObject missilePowerUp1;
	public GameObject missilePowerUp2;





	void Awake() {
		PhotonNetwork.ConnectUsingSettings ("v4.2");
		PhotonNetwork.sendRate = 60;
		PhotonNetwork.sendRateOnSerialize = 60;
	}

	public void LoadScene(int level)
	{
		Application.LoadLevel(level);
	
	}


	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Wall (1)" || col.gameObject.name == "Wall (2)" || col.gameObject.name == "Wall (3)" || col.gameObject.name == "Wall (4)" 
		    || col.gameObject.name == "Cycle Trail 1(Clone)" || col.gameObject.name == "level1HoleWall" || col.gameObject.name == "Wall (5)" || col.gameObject.name == "Wall (6)"
		    || col.gameObject.name == "Wall (7)" || col.gameObject.name == "Wall (8)" || col.gameObject.name == "Wall (9)" || col.gameObject.name == "Wall (3) half left" 
		    || col.gameObject.name == "Wall (3) half right" || col.gameObject.name == "Cycle Trail 2(Clone)" || col.gameObject.name == "Cycle Trail AI1(Clone)" || 
		    col.gameObject.name == "Cycle Trail Missile(Clone)") {
			Application.LoadLevel(0);
			PhotonNetwork.Disconnect();
		}
		if (col.gameObject.name == "Wall (10)") {
			LoadScene (2);
		}
		if (col.gameObject.name == "missilePowerUp1") {
			Debug.Log("poop1");
			missilePowerUp1.transform.localPosition=new Vector3 (Random.Range (-175.0f, 175.0f),3.0f,-100.0f);
			GetComponent<ShootingPowerUp>().shooting=GetComponent<ShootingPowerUp>().shooting+2;
			Debug.Log(GetComponent<ShootingPowerUp>().shooting);
		}
		if (col.gameObject.name == "missilePowerUp2") {
			Debug.Log("poop2");
			missilePowerUp2.transform.localPosition=new Vector3 (Random.Range (-175.0f, 175.0f),3.0f,100.0f);
			GetComponent<ShootingPowerUp>().shooting=GetComponent<ShootingPowerUp>().shooting+2;
			Debug.Log(GetComponent<ShootingPowerUp>().shooting);
		}




	}

}

