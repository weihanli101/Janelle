using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	public GameObject joystick;
	public float MovementSpeed;
	public float jumpPower;

	private Rigidbody2D rbPlayer;
	private Vector2 playerMoveVector;
	
	
	void Start () {
		rbPlayer = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		UpdateAnimations();
		
		playerMoveVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 0) * MovementSpeed;
		//rbPlayer.AddForce(playerMoveVector);
		rbPlayer.velocity = playerMoveVector;
		if (transform.position.y <= -4.65f) {
			GetComponent<BoxCollider2D>().enabled = true;
		}
		
		for (int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.touches[i];
			//left = jump
			if (touch.position.x > Screen.width / 2) {
				//init fall, unless if it is the last floor
				if (touch.phase == TouchPhase.Began &&  transform.position.y > -4.65f) {
					GetComponent<BoxCollider2D>().enabled = false;
					//faster falling add gravity
					rbPlayer.gravityScale = 100f;
				}
				//turn the collider back on
				else if (touch.phase == TouchPhase.Ended) {
					GetComponent<BoxCollider2D>().enabled = true;
				}
			}
		}
	}
	
	private void OnTriggerEnter2D(Collider2D other) {
		//reset the gravity scale when not falling
		if (other.CompareTag("Ground") && CompareTag("Player")) {
			rbPlayer.gravityScale = 1f;
		}
	}

	private void UpdateAnimations(){
		// left
		if (rbPlayer.velocity.x < 0) {
			GetComponent<SpriteRenderer>().flipX = true;
			GetComponent<Animator>().SetBool("isWalking", true);
		}
		//right
		else if (rbPlayer.velocity.x > 0) {
			GetComponent<SpriteRenderer>().flipX = false;
			GetComponent<Animator>().SetBool("isWalking", true);

		}
		else {
			GetComponent<Animator>().SetBool("isWalking", false);
		}
	}
}
