using UnityEngine;
using UnityEngine.UI;

public class ComboTextController : MonoBehaviour {

    public float minimum;
    public float maximum;
    public float lerpSpeed;

    private static float t = 0.0f;
    private GameController _gameController;

    private void Start() {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void FixedUpdate() {
        updateLerpSpeed();
        GetComponent<Text>().fontSize = (int) Mathf.Lerp(minimum,maximum,t);
        t += lerpSpeed * Time.deltaTime;

        if (t > 1) {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0f;
        }
    }

    private void updateLerpSpeed() {
        lerpSpeed = (-1*(1f / (0.1f * (_gameController.combo + 3.5f)))) + 4;
    }
}
