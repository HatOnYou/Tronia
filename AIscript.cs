using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIscript : MonoBehaviour {
	public GameObject AI1;
	public GameObject player;
	public GameObject[] AItrail;
	public Transform target;
	public string trail;

	// Use this for initialization
	void Start () {
		AItrail = GameObject.FindGameObjectsWithTag ("AItrail");
	}
	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Wall (1)" || col.gameObject.name == "Wall (2)" || col.gameObject.name == "Wall (3)" || col.gameObject.name == "Wall (4)" 
			|| col.gameObject.name == "Cycle Trail(Clone)" || col.gameObject.name == "level1HoleWall" || col.gameObject.name == "Wall (5)" || col.gameObject.name == "Wall (6)"
			|| col.gameObject.name == "Wall (7)" || col.gameObject.name == "Wall (8)" || col.gameObject.name == "Wall (9)" || col.gameObject.name == "Wall (10)" 
			|| col.gameObject.name == "Wall (3) half left" || col.gameObject.name == "Wall (3) half right") {
			Destroy (AI1);
			AItrail = GameObject.FindGameObjectsWithTag("AItrail");
			for(int i = 0; i < AItrail.Length; i++)
			{
				Destroy(AItrail[i].gameObject);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
		if (AI1.transform.position.x - player.transform.position.x > 0) {
			AI1.transform.Rotate (0, 30, 0);
		} else {
			AI1.transform.Rotate (0, -30, 0);
		} 

		if (AI1.transform.position.z - player.transform.position.z < 0) {
			AI1.transform.Rotate (0, 25, 0);
		} else {
			AI1.transform.Rotate (0, 5, 0);
		}
	}
}
	