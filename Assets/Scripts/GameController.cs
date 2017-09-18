using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour {
	
	void Start () {
		
		StartCoroutine(MovePortals());
	}
	
	void Update () {
		
	}

	IEnumerator MovePortals() {
		
		//TODO: chnage game conditionlater
		while (Time.realtimeSinceStartup < 100) {
			yield return new WaitForSeconds (1);
		}		
	}
}
