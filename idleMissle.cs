using UnityEngine;
using System.Collections;
using Photon;

public class idleMissle : Photon.MonoBehaviour {
	float upOrDown;
	// Use this for initialization
	void Awake () {
		upOrDown = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0, 0, 0.6f);
		transform.position += transform.forward * Time.deltaTime*upOrDown;
		if (transform.position.y > 4){
			upOrDown=-1.0f;
		}
		if (transform.position.y < 3){
			upOrDown=1.0f;
		}
	}
}
