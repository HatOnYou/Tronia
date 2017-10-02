using UnityEngine;
using System.Collections;

public class Actualmovement : Photon.MonoBehaviour {

	public float speed;

	// Update is called once per frame
	public void Update () {

		this.transform.position = this.transform.position + this.transform.forward * speed * Time.deltaTime;
	}
}
