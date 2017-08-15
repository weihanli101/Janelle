using UnityEngine;

public class JanelleController : MonoBehaviour {
	public GameObject player;
	public float speed;
	private Rigidbody2D rbPlayer;
	
	void Start () {
		rbPlayer = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
		UpdateAnimations();
		rbPlayer.velocity = Vector3.MoveTowards(transform.position, player.GetComponent<Transform>().position, 1) * speed;
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
