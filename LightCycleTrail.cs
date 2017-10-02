using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightCycleTrail : Photon.MonoBehaviour {

	public GameObject Trail;
	public GameObject Player;
	public GameObject Cam;
	public float timer;
	public GameObject trailBox;
	Vector3 trailPos;
	// Use this for initialization
	void Awake () {
		PhotonNetwork.sendRate = 60;
		PhotonNetwork.sendRateOnSerialize = 60;
		//Trail.transform.rotation = Player.transform.rotation;
		//GameObject SpawnLocation = (GameObject)Instantiate(Trail,spawnLocation,Quaternion.identity);
	}

	void trail (){
		Trail.transform.position = this.transform.position - this.transform.forward *2.0f;
		Cam.transform.position = this.transform.position + new Vector3 (0, 0.8f, 0);
	//	if (timer >= 0.05f) {
			GameObject SpawnLocation = (GameObject)Instantiate (Trail, Trail.transform.position, this.transform.rotation);
	//		timer=0.0f;
	//	}
	}

	// Update is called once per frame
	void Update () {
		//timer += Time.deltaTime;
		//Debug.Log (timer);
		trail ();
		if (photonView.isMine) {

		} else {

			
		}
	}
}