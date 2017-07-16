using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	public GameObject joystick;
	public float MovementSpeed;

	private Rigidbody2D rbPlayer;
	private Vector2 playerMoveVector;
	
	void Start () {
		rbPlayer = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		playerMoveVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * MovementSpeed;
		rbPlayer.AddForce(playerMoveVector);
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (CompareTag("Player") && other.CompareTag("Ladder")) {
			playerMoveVector = new Vector2(0, CrossPlatformInputManager.GetAxis("Vertical")) * MovementSpeed;
			rbPlayer.AddForce(playerMoveVector);
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		playerMoveVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical")) * MovementSpeed;
		rbPlayer.AddForce(playerMoveVector);
	}
}
