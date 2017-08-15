using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject leftPortal;
	public GameObject rightPortal;
	public float portalMovingRate;

	private int randNumForLeftPortal;
	private int randNumForRightPortal;
	
	void Start () {
		
		StartCoroutine(MovePortals());
	}
	
	void Update () {
		
	}

	IEnumerator MovePortals() {
		
		//TODO: chnage game conditionlater
		while (Time.realtimeSinceStartup < 100) {
			randNumForLeftPortal = Random.Range(0, 4);
			randNumForRightPortal = Random.Range(0, 4);
			
			//for left portal
			//top floor
			if (randNumForLeftPortal == 0 ) {
				leftPortal.GetComponent<Transform>().position = new Vector2(leftPortal.GetComponent<Transform>().position.x, 2.3f);
			}
			//middle floor
			else if (randNumForLeftPortal == 1) {
				leftPortal.GetComponent<Transform>().position = new Vector2(leftPortal.GetComponent<Transform>().position.x, -0.28f);
			}
			//main floor
			else if (randNumForLeftPortal == 2) {
				leftPortal.GetComponent<Transform>().position = new Vector2(leftPortal.GetComponent<Transform>().position.x, -3.05f);
			}
			//basement
			else if (randNumForLeftPortal == 3) {
				leftPortal.GetComponent<Transform>().position = new Vector2(leftPortal.GetComponent<Transform>().position.x, -6.37f);
			}
			
			//right portal
			//top floor
			if (randNumForRightPortal == 0 ) {
				rightPortal.GetComponent<Transform>().position = new Vector2(rightPortal.GetComponent<Transform>().position.x, 2.3f);
			}
			//middle floor
			else if (randNumForRightPortal == 1) {
				rightPortal.GetComponent<Transform>().position = new Vector2(rightPortal.GetComponent<Transform>().position.x, -0.28f);
			}
			//main floor
			else if (randNumForRightPortal == 2) {
				rightPortal.GetComponent<Transform>().position = new Vector2(rightPortal.GetComponent<Transform>().position.x, -3.05f);
			}
			//basement
			else if (randNumForRightPortal == 3) {
				rightPortal.GetComponent<Transform>().position = new Vector2(rightPortal.GetComponent<Transform>().position.x, -6.37f);
			}
			yield return new WaitForSeconds (portalMovingRate);
		}		
	}
}
