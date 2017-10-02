using UnityEngine;
using System.Collections;
using Photon;

public class NetworkManager : Photon.MonoBehaviour {
	
	private const string roomName = "Other Player";
	private TypedLobby lobbyName = new TypedLobby("New_Lobby", LobbyType.Default);
	private RoomInfo[] roomsList;
	public GameObject player1Prefab;
	public GameObject player2Prefab;
	public int playerNum;
	public Camera camera1;
	public Camera camera2;
    
	
	void Awake() {
		PhotonNetwork.ConnectUsingSettings ("v4.2");
		camera1.enabled = true;
		camera2.enabled = false;
		playerNum = 0;
		PhotonNetwork.sendRate = 60;
		PhotonNetwork.sendRateOnSerialize = 60;
	}


	void OnReceivedRoomListUpdate()
	{
		Debug.Log ("Room was created");
		roomsList = PhotonNetwork.GetRoomList();
	}

	void OnJoinedLobby() {
		Debug.Log ("Joined Lobby");
	}

	void OnConnectedToMaster(){
		PhotonNetwork.JoinLobby(lobbyName);
	}

	void OnJoinedRoom()
	{
		Debug.Log ("Connected to Room");
		if (playerNum==0) {
			PhotonNetwork.Instantiate (player1Prefab.name, new Vector3 (Random.Range (105.0f, 175.0f), 1f, Random.Range (-50.0f, 50.0f)), Quaternion.Euler(new Vector3(0, -90, 0)), 0);
            Debug.Log (playerNum);
		} 
		if (playerNum==1) {
			camera1.enabled = false;
			camera2.enabled = true;
			PhotonNetwork.Instantiate (player2Prefab.name, new Vector3 (Random.Range (-105.0f, -175.0f), 1f, Random.Range (-50.0f, 50.0f)), Quaternion.Euler(new Vector3(0, 90, 0)), 0);
			Debug.Log (playerNum);
		} 

	}

	 void OnGUI(){
		if (!PhotonNetwork.connected) {
			GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		} else if (PhotonNetwork.room == null){
			//Create room

            if (GUI.Button(new Rect(100, 100, 150, 75), "Start Server (Press R)") || Input.GetKey(KeyCode.R))
            {
				//PhotonNetwork.CreateRoom(roomName, new RoomOptions(){maxPlayers = 4, isOpen = true, isVisible = true}, lobbyName);
				PhotonNetwork.CreateRoom(roomName, new RoomOptions(){isOpen = true, isVisible = true, maxPlayers = 4}, lobbyName);
				Debug.Log("Hello!");
			} 
			if (GUI.Button(new Rect(300, 100, 150, 75), "The Grid")){
				Application.LoadLevel(0);
				PhotonNetwork.Disconnect();
			} 
			if (GUI.Button(new Rect(500, 100, 150, 75), "Crossover")){
				Application.LoadLevel(1);
				PhotonNetwork.Disconnect();
			} 
			if (GUI.Button(new Rect(500, 200, 150, 75), "Turn down")){
				Application.LoadLevel(2);
				PhotonNetwork.Disconnect();
			}
			if (GUI.Button(new Rect(300, 300, 350, 75), "Move mouse left and right to turn")){
			}
			if (GUI.Button(new Rect(300, 400, 150, 75), "Left click to boost")){
			}
			if (GUI.Button(new Rect(500, 400, 150, 75), "Right click to fire missile")){
			}
			if (roomsList != null){
				for (int i = 0; i < roomsList.Length; i++){
					if (GUI.Button (new Rect(100, 250 + (110*i), 250, 100), "Join " + roomsList[i].name)){
						PhotonNetwork.JoinRoom(roomName);
						playerNum++;
						Debug.Log (playerNum);
					}
				}
			}
		}
	}
}