using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScoreManager : MonoBehaviour {

	public static int score;
	Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();
		score = 190;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Money: $" + score;
	}
}
