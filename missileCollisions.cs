using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Photon;

public class missileCollisions : Photon.MonoBehaviour {
	public GameObject missile;
	public GameObject[] missileTrail;
	
	void Awake() {
		PhotonNetwork.ConnectUsingSettings ("v4.2");
		PhotonNetwork.sendRate = 60;
		PhotonNetwork.sendRateOnSerialize = 60;
	}
	
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Wall (1)" || col.gameObject.name == "Wall (2)" || col.gameObject.name == "Wall (3)" || col.gameObject.name == "Wall (4)" 
		    || col.gameObject.name == "Cycle Trail 1(Clone)" || col.gameObject.name == "level1HoleWall" || col.gameObject.name == "Wall (5)" || col.gameObject.name == "Wall (6)"
		    || col.gameObject.name == "Wall (7)" || col.gameObject.name == "Wall (8)" || col.gameObject.name == "Wall (9)" || col.gameObject.name == "Wall (3) half left" 
		    || col.gameObject.name == "Wall (3) half right" || col.gameObject.name == "Cycle Trail 2(Clone)" || col.gameObject.name == "Cycle Trail AI1(Clone)") {
			missileTrail = GameObject.FindGameObjectsWithTag("missileTrail");
			for(int i = 0; i < missileTrail.Length; i++)
			{
				Destroy(missileTrail[i].gameObject);
			}
			Destroy(missile);
		}
	}
	
}

