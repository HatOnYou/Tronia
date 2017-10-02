using UnityEngine;
using System.Collections;
using Photon;

public class ShootingPowerUp : Photon.MonoBehaviour {
	public int shooting;
	public GameObject shot;
	public GameObject player;
	// Use this for initialization
	void Awake()
	{
		PhotonNetwork.ConnectUsingSettings ("v4.2");
		PhotonNetwork.sendRate = 60;
		PhotonNetwork.sendRateOnSerialize = 60;
	}

	void Start () {
		shooting = 0;
	}
	
	// Update is called once per frame
	void Update () {
		shot.transform.position = player.transform.position + player.transform.forward *10.0f +player.transform.right*5.0f;
        if (Input.GetKey(KeyCode.DownArrow) && shooting > 0)
        {
			PhotonNetwork.Instantiate (shot.name,shot.transform.position, player.transform.rotation,0);
			shooting=shooting-2;
			Debug.Log(shooting);
		}

	}
}
