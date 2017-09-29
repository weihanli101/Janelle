using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {
	public GameObject joystick;
	public float MovementSpeed;
	public float jumpPower;

    //audio clips
    public AudioClip collectSound;

	private Rigidbody2D rbPlayer;
	private Vector2 playerMoveVector;
    private float fallTimer;
    private float timeSinceLastCombo;
    private GameController _gameController;
	
	
	void Start () {
		rbPlayer = GetComponent<Rigidbody2D>();
        fallTimer = 0.0f;
        timeSinceLastCombo = 0.0f;
		_gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}
	
	void FixedUpdate () {
        //update combo time
        timeSinceLastCombo += Time.deltaTime;
        if(timeSinceLastCombo>1.5f){
            _gameController.combo = 1;
        }
		UpdateAnimations();
		playerMoveVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), 0) * MovementSpeed;
		rbPlayer.velocity = playerMoveVector;
		if (transform.position.y <= -4.65f) {
			GetComponent<BoxCollider2D>().enabled = true;
		}
		
		for (int i = 0; i < Input.touchCount; i++) {
			Touch touch = Input.touches[i];
			//left = jump
			if (touch.position.x > Screen.width / 2) {
				//init fall, unless if it is the last floors
                //TODO: fix bug where you can hold down the button
				if (touch.phase == TouchPhase.Began &&  transform.position.y > -4.65f) {
					GetComponent<BoxCollider2D>().enabled = false;
					//faster falling add gravity
					rbPlayer.gravityScale = 100f;
                    fallTimer += Time.deltaTime;
                    if(fallTimer > 0.5f){
                        GetComponent<BoxCollider2D>().enabled = true;
                        fallTimer = 0;
                    }
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
        //add to bonus points
        if (other.CompareTag("Pickup") && CompareTag("Player")){
            GetComponent<AudioSource>().PlayOneShot(collectSound);
            _gameController.combo += 1;
            if(_gameController.combo >= 99){
                _gameController.combo = 99;
            }
            timeSinceLastCombo = 0.0f;
            Destroy(other.gameObject);
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
