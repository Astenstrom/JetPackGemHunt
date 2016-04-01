using UnityEngine;
using System.Collections;

public class SwitchCamera : MonoBehaviour {

	public GameObject camera1;
	public GameObject camera2;

	// Use this for initialization
	void Start () {
		camera1.SetActive (true);
		camera2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A)) {
			camera1.SetActive (false);
			camera2.SetActive (true);
		}
		if (Input.GetKey (KeyCode.S)) {
			camera1.SetActive (true);
			camera2.SetActive (false);
		}
	}

}