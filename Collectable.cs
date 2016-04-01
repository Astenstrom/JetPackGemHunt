using UnityEngine;
using System.Collections;


public class Collectable : MonoBehaviour {

	public RandomSprites randomSprites;
	private AudioSource source;
	private GameObject player;

	//RandomSprites currentSprite;
	// Use this for initialization
	void Awake () {
		player = GameObject.Find ("Player");
		source = player.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target){
		source.Play();

		if (target.gameObject.tag == "Player")
			ScoreManager.score += 10;
			Destroy (gameObject);
	}

	void updateScore(){
		if (randomSprites.currentSprite % 2 == 1)
			ScoreManager.score += 100;
		else
			ScoreManager.score += 50;
	}
}
