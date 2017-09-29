using UnityEngine;

public class PlayerArrowController : MonoBehaviour {

    public float minimum;
    public float maximum;
    public float lerpSpeed;

    private static float t = 0.0f;


    void FixedUpdate() {
        transform.localPosition = new Vector2(0, Mathf.Lerp(minimum,maximum,t));
        t += lerpSpeed * Time.deltaTime;

        if (t > 1) {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0f;
        }
    }
}

