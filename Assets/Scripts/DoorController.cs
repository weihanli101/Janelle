using UnityEngine;

public class DoorController : MonoBehaviour {
    public GameObject Player;
    public GameObject Janelle;

    public GameObject basementLeftDoor;
    public GameObject basementRightDoor;
    public GameObject mainFloorLeftDoor;
    public GameObject mainFloorRightDoor;
    public GameObject midFloorLeftDoor;
    public GameObject midFloorRightDoor;
    public GameObject topFloorLeftDoor;
    public GameObject topFloorRightDoor;

    void Start() {

    }

    void Update() {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        //if the player or janelle touches the door proc animation && move
        if (other.CompareTag("Janelle")) {
            GetComponent<Animator>().SetTrigger("useDoor");
        }
        if (other.CompareTag("Player")) {
            GetComponent<Animator>().SetTrigger("useDoor");
            moveToAnotherDoor(true);
        }
    }

    private void moveToAnotherDoor(bool isPlayer) {
        if (isPlayer) {
            //Door Left Basement --> Door Right Main Floor
            if (this.gameObject.name.Equals("Door Left Basement")) {
                Player.GetComponent<Transform>().position = new Vector2(3.5f, -3.13f);
            //pop the animation of the exit door manually since you tp the char slightly to the side
                GameObject.Find("Door Right Main Floor").GetComponent<Animator>().SetTrigger("useDoor");
            }

            //Door Right Main Floor --> Door Left Basement
            else if (this.gameObject.name.Equals("Door Right Main Floor")) {
                Player.GetComponent<Transform>().position = new Vector2(-3.6f, -6.51f);
                GameObject.Find("Door Left Basement").GetComponent<Animator>().SetTrigger("useDoor");
            }

            //Door Right Basement --> Door Left Top Floor
            else if (this.gameObject.name.Equals("Door Right Basement")) {
                Player.GetComponent<Transform>().position = new Vector2(-3.6f, 2.3f);
                GameObject.Find("Door Left Top Floor").GetComponent<Animator>().SetTrigger("useDoor");
            }

            //Door Left Top Floor --> Door Right Basement
            else if (this.gameObject.name.Equals("Door Left Top Floor")) {
                Player.GetComponent<Transform>().position = new Vector2(3.5f, -6.51f);
                GameObject.Find("Door Right Basement").GetComponent<Animator>().SetTrigger("useDoor");
            }

            //Door Left Main Floor --> Door Right Top Floor
            else if (this.gameObject.name.Equals("Door Left Main Floor")) {
                Player.GetComponent<Transform>().position = new Vector2(3.5f, 2.3f);
                GameObject.Find("Door Right Top Floor").GetComponent<Animator>().SetTrigger("useDoor");
            }


            //Door Right Top Floor --> Door Left Mid Floor
            else if (this.gameObject.name.Equals("Door Right Top Floor")) {
                Player.GetComponent<Transform>().position = new Vector2(-3.6f, -0.3f);
                GameObject.Find("Door Left Mid Floor").GetComponent<Animator>().SetTrigger("useDoor");
            }

            // Door Left Mid Floor -->  Door Right Mid Floor
            else if (this.gameObject.name.Equals("Door Left Mid Floor")) {
                Player.GetComponent<Transform>().position = new Vector2(3.5f, -0.3f);
                GameObject.Find("Door Right Mid Floor").GetComponent<Animator>().SetTrigger("useDoor");
            }

            //Door Right Mid Floor --> Door Left Main Floor
            else if (this.gameObject.name.Equals("Door Right Mid Floor")) {
                Player.GetComponent<Transform>().position = new Vector2(-3.6f, -3.13f);
                GameObject.Find("Door Left Main Floor").GetComponent<Animator>().SetTrigger("useDoor");
            }

        }
    }

}
