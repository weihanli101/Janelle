using UnityEngine;

public class RightPortalController : MonoBehaviour {
	public GameObject leftPortal;
	public GameObject player;

	private Vector2 teleVector2;

	
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player") && CompareTag("PortalRight")) {
			//move slightly infront so you dont tele back
			teleVector2 = new Vector2(leftPortal.GetComponent<Transform>().position.x + 1, leftPortal.GetComponent<Transform>().position.y);
			player.GetComponent<Transform>().position = teleVector2;
			print("Right Portal");
			
		}
		
		if (other.CompareTag("Janelle") && CompareTag("PortalRight")) {
			//move slightly infront so you dont tele back
			teleVector2 = new Vector2(leftPortal.GetComponent<Transform>().position.x + 1.2f, leftPortal.GetComponent<Transform>().position.y);
			other.GetComponent<Transform>().position = teleVector2;
			print("Right Portal");
		}
	}
}
