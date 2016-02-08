using UnityEngine;
using System.Collections;

public class PipeCollector : MonoBehaviour {

	private GameObject[] pipeHolders;
	private float distanceBetweenPipes = 2.5f;
	private float lastPipesX;
	
	// calculate high and lows of pipes
	private float pipeMinYPos = .64f;
	private float pipeMaxYPos = 2.5f;

	// 59
	void Awake() {
	
		pipeHolders = GameObject.FindGameObjectsWithTag("PipeHolder");
		
		
		// create random Y positions for pipes at the start
		for (int i = 0; i < pipeHolders.Length; i++) {
			Vector3 temp = pipeHolders[i].transform.position;
			temp.y = Random.Range(pipeMinYPos, pipeMaxYPos);
			pipeHolders[i].transform.position = temp;
		}
		
		
		// assign position, to move pipes to the right 
		lastPipesX = pipeHolders[0].transform.position.x;
		
		for (int i = 1; i < pipeHolders.Length; i++) {
			if(lastPipesX < pipeHolders [i].transform.position.x) {
				lastPipesX = pipeHolders [i].transform.position.x;
			}
		}
		
		
	
	}


	void OnTriggerEnter2D(Collider2D target) {
	
	
		// 59 - 10:40
		// shift pipes to the right
		if (target.tag == "PipeHolder") {
		
			Vector3 temp = target.transform.position;
			
			temp.x = lastPipesX + distanceBetweenPipes;
			temp.y = Random.Range(pipeMinYPos, pipeMaxYPos);
		
			target.transform.position = temp;
			
			lastPipesX = temp.x;
		
		
		}
	
	
	
	
	
	}

	
	
	
}
















