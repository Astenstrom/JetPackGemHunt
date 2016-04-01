using UnityEngine;
using System.Collections;

public class NPC_Dialogue : MonoBehaviour {

	public string[] answerButtons;
	public string[] Questions;
	bool displayDialogue = false;
	bool ActivateQuest = false;
	bool reachedGoal = false;  //unlock place to stay
	bool reachedGoal1 = false;  //unlock church
	bool reachedGoal2 = false;  //unlock shop
	bool reachedGoal3 = false; //unlock Inn
	bool checkBrought = false; //bool to decide if the old man needs to check wht you've brought
	public string scene;
	private int counter;
	private GameObject shopKeeper;
	private GameObject innKeeper;
	private GameObject churchKeeper;

	// Use this for initialization
	void Start () {
		//GameObject.FindWithTag("ChurchKeeper").SetActive(false);
		shopKeeper = GameObject.FindWithTag("ShopKeeper");
		innKeeper = GameObject.FindWithTag("InnKeeper");
		churchKeeper = GameObject.FindWithTag("ChurchKeeper");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUILayout.BeginArea (new Rect (200, 200, 400, 400));

		if (displayDialogue && !ActivateQuest) {
			GUILayout.Label (Questions [0]);
			GUILayout.Label (Questions [1]);

			if (GUILayout.Button (answerButtons [0])) {
				ActivateQuest = true;
				checkBrought = true;
				displayDialogue = false;
			}

			if (GUILayout.Button (answerButtons [1])) {
				displayDialogue = false;
			}
		}
			
		// Checks to see how much you have brought him 
		if(displayDialogue && ActivateQuest && checkBrought){
			GUILayout.Label (Questions [2]);

			if (GUILayout.Button (answerButtons [2])) {
				if(ScoreManager.score >= 100){
					reachedGoal = true;
					checkBrought = false;
				}
				if (ScoreManager.score >= 200) {
					reachedGoal1 = true;
					checkBrought = false;
				}
				if (ScoreManager.score >= 300) {
					reachedGoal2 = true;
					checkBrought = false;
				}
				if (ScoreManager.score >= 300) {
					reachedGoal3 = true;
					checkBrought = false;
				}

				else{
					displayDialogue = false;
					checkBrought = true;
				}
			}
		}

		//You got your house and he asks you to help rebuild the town
		if(displayDialogue && ActivateQuest && reachedGoal && !reachedGoal1 && !reachedGoal2 && !reachedGoal3){
			GUILayout.Label (Questions [3]);
			
			if (GUILayout.Button (answerButtons [3])) { //you agree to help him
				displayDialogue = false;
				checkBrought = true;
			}
			
			if (GUILayout.Button (answerButtons [4])) {
				displayDialogue = false;
			}
		}
		
		//second goal re-open church
		if(displayDialogue && ActivateQuest && reachedGoal1 && !reachedGoal2 && !reachedGoal3){
			GUILayout.Label (Questions [4]);

			if (GUILayout.Button (answerButtons [3])) { //you agree to help him
					
				displayDialogue = false;
				Destroy (GameObject.FindWithTag("Church"));
				churchKeeper.transform.position = new Vector3(47.95f, 1.75f, 0f);
				checkBrought = true;
			}
				
			if (GUILayout.Button (answerButtons [4])) {
				displayDialogue = false;
			}
//			StartWait();
//			Application.LoadLevel(scene);
		}

		// Goal to re-open shop
		if(displayDialogue && ActivateQuest && reachedGoal && reachedGoal1 && reachedGoal2 && !reachedGoal3){
			GUILayout.Label (Questions [5]);

			if (GUILayout.Button (answerButtons [3])) { //you agree to help him
					
				displayDialogue = false;
				Destroy (GameObject.FindWithTag("Shop"));
				shopKeeper.transform.position = new Vector3(-5.52f,1.63f,0);
				checkBrought = true;
			}
				
			if (GUILayout.Button (answerButtons [4])) {
				displayDialogue = false;
			}
			//			StartWait();
			//			Application.LoadLevel(scene);
		}

		//Goal to re-open Inn
		if(displayDialogue && ActivateQuest && reachedGoal && reachedGoal1 && reachedGoal2 && reachedGoal3){
			GUILayout.Label (Questions [6]);
				
			if (GUILayout.Button (answerButtons [3])) { //you agree to help him
				displayDialogue = false;
				Destroy (GameObject.FindWithTag("Inn"));
				innKeeper.transform.position = new Vector3(39.27f,1.75f,0f);
				checkBrought = true;
			}
				
			if (GUILayout.Button (answerButtons [4])) {
				displayDialogue = false;
			}
			//			StartWait();
			//			Application.LoadLevel(scene);
		}
	

		GUILayout.EndArea();

	}

	void OnTriggerEnter2D(){
		displayDialogue = true;
	}

	void OnTriggerExit2D(){
		displayDialogue = false;
	}

	IEnumerator StartWait ()
	{
		yield return new WaitForSeconds(10);
	}
}
