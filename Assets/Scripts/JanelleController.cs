using UnityEngine;

public class JanelleController : MonoBehaviour {
	public GameObject player;
	public float speed;

    //Audio
    public AudioClip yayClip;
    public AudioClip hugClip;
    public AudioClip noClip;
    public AudioClip loveClip;

    //ui
    public GameObject hugText;

	private Rigidbody2D rbPlayer;
	private Vector3 movementPos;
	private bool directionBool;

	void Start () {
        directionBool = false;
		rbPlayer = GetComponent<Rigidbody2D>();
        InvokeRepeating("updateBool", 0f, 5f);
	}
	
	void FixedUpdate () {

        if((player.GetComponent<Transform>().position.y > transform.position.y+1 || player.GetComponent<Transform>().position.y < transform.position.y-1)){
            if(directionBool == false){
                GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            }
            else if(directionBool == true){
                GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            }
        }

        else{
            if(player.GetComponent<Transform>().position.x > transform.position.x +1){
                GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
            }
            else if(player.GetComponent<Transform>().position.x < transform.position.x -1){
                GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
            }
        }

        UpdateAnimations();
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

    private void updateBool(){
        if(directionBool == true){
            directionBool = false;
        }
        else if(directionBool == false){
            directionBool = true;
        }
    }
}
