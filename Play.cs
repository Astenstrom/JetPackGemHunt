using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {

	// Use this for initialization
	void Start () {
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
		GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
