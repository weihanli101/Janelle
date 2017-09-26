using UnityEngine;

public class FoodController : MonoBehaviour {
	public float oscillateSpeed;
    private float t;
    private float minimum;
    private float maximum;

	// Use this for initialization
	void Start (){
        //for oscillation
        minimum = GetComponent<Transform>().position.y;
        maximum = minimum + 0.1f;
	}

	void Update () {
//for oscillation
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(minimum, maximum, t), transform.position.z);

        t += oscillateSpeed * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }

	}
}
