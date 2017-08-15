using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player;
	// animate the game object from -1 to +1 and back
	public float minimum;
	public float maximum;
	private int switchFlag;

	// starting value for the Lerp
	private static float t;

	private void Start() {
		//0 for top and 1 for bottom
		switchFlag = 0;
	}

	void Update() {
		t += 2f * Time.deltaTime;
		transform.position = new Vector3(0, Mathf.Lerp(minimum, maximum, t), -10);
		
		if (player.GetComponent<Transform>().position.y < -4.56f && switchFlag == 1) {
			float temp = maximum;
			maximum = minimum;
			minimum = temp;
			t = 0.0f;
			switchFlag = 0;

		}
			
		else if (player.GetComponent<Transform>().position.y > -4.56f && switchFlag == 0) {
			float temp = maximum;
			maximum = minimum;
			minimum = temp;
			t = 0.0f;
			switchFlag = 1;
		}
	}
}
