using UnityEngine;
using System.Collections;

public class PointBall: MonoBehaviour {
	public GameObject pacman;
	public static bool started = true;
	// Use this for initialization
	void Start() {
		if (PointBall.started == true) {
			Invoke("createBalls", 1);
		}
	}

	// Update is called once per frame
	void Update() {
		
	}

	void createBalls() {
		Instantiate(gameObject, new Vector3(5.0F, 0.3F, 0F), Quaternion.identity);
		Instantiate(gameObject, new Vector3(-5.52F, -4.36F, 0F), Quaternion.identity);
		Instantiate(gameObject, new Vector3(5.55F, -4.36F, 0F), Quaternion.identity);
		PointBall.started = false;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.name == pacman.name) {
			// Debug.Log("Pacman gets the ball");
			Destroy(gameObject);
		}
	}
}