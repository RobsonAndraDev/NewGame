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
		float ballScaleX = transform.localScale.x,
					ballScaleY = transform.localScale.y,
					ballSize = 0.6F,
					x = transform.position.x,
					y = transform.position.y;

		for (var col = 0; col < 16; col++) {
			//column implementation
			for (int row = 0; row < 20; row++)
			{
				Instantiate(gameObject, new Vector3(x, y, 0F), Quaternion.identity);
				x += ballSize;
			}
			y -= ballSize;
			x = transform.position.x;
		}
		PointBall.started = false;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.gameObject.name == pacman.name) {
			Destroy(gameObject);
		}
	}
}

/*
	col 0 row[1,2,3,]
*/