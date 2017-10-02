using UnityEngine;
using System.Collections;
using Photon;

public class LoadingScript : Photon.MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(0);
            PhotonNetwork.Disconnect();
        }
            
            this.transform.Rotate (0, 0, 0.0f);
	}
}
