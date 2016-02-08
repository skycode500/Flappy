using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public static MenuController instance;
	
	[SerializeField]
	private GameObject[] birds;
	
	private bool isGreenBirdUnlocked;
	private bool isRedBirdUnlocked;
	
	void MakeInstance() {
	
		if(instance == null) {
			instance = this;
		}
	
	}
	
	void CheckIfBirdsAreUnlocked() {
	
		if(GameController.instance.IsRedBirdUnlocked () == 1) {
			isRedBirdUnlocked = true;
		}
		
		if(GameController.instance.IsGreenBirdUnlocked () == 1) {
			isGreenBirdUnlocked = true;
		}
	
	}
	
	

	void Awake() {
		MakeInstance();
		
		//PlayerPrefs.DeleteAll() // restart configs
	}


	// Use this for initialization
	void Start () {
		// 64 - 1:40
		// Will activate which bird is active
		birds[GameController.instance.GetSelectedBird()].SetActive(true);
		CheckIfBirdsAreUnlocked();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	
	public void PlayGame() {
		SceneFader.instance.FadeIn("Gameplay");	

	}
	
	
	//64 - 3:05 - his algo is basically selecting the bird, but it has to go in order from blue, green, then red
	public void ChangeBird() {
		
		if (GameController.instance.GetSelectedBird () == 0) {
		
			if(isGreenBirdUnlocked) {
				birds[0].SetActive(false);
				GameController.instance.SetSelectedBird(1);
				birds[GameController.instance.GetSelectedBird ()].SetActive (true);
			} 
			
		} else if (GameController.instance.GetSelectedBird () == 1) {
			
			if(isRedBirdUnlocked) {
			
				birds[1].SetActive(false);
				GameController.instance.SetSelectedBird(2);
				birds[GameController.instance.GetSelectedBird ()].SetActive (true);
				
		}else  {
			
				birds[1].SetActive(false);
				GameController.instance.SetSelectedBird(0);
				birds[GameController.instance.GetSelectedBird ()].SetActive (true);
			
		  }
		} else if  (GameController.instance.GetSelectedBird () == 2) {
			birds[2].SetActive(false);
			GameController.instance.SetSelectedBird(0);
			birds[GameController.instance.GetSelectedBird ()].SetActive (true);
			
		}
		
	}
	
	
}


















