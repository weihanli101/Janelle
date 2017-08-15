using UnityEngine;

public class LeftPortalController : MonoBehaviour {
	public GameObject rightPortal;
	public GameObject player;

	private Vector2 teleVector2;

	
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Player") && CompareTag("PortalLeft")) {
			teleVector2 = new Vector2(rightPortal.GetComponent<Transform>().position.x - 1, rightPortal.GetComponent<Transform>().position.y);
			player.GetComponent<Transform>().position = teleVector2;
			print("Left Portal");
		}
		if (other.CompareTag("Janelle") && CompareTag("PortalLeft")) {
			teleVector2 = new Vector2(rightPortal.GetComponent<Transform>().position.x - 1.2f, rightPortal.GetComponent<Transform>().position.y);
			other.GetComponent<Transform>().position = teleVector2;
			print("Left Portal");
		}
	}
}
