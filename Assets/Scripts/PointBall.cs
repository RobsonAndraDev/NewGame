using UnityEngine;
using System.Collections;
using System.Linq;

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

		for (int row = 0; row < 16; row++) {
			for (var col = 0; col < 19; col++) {
				if ( !(new ArrayList{1, 2, 3, 16, 17}.Contains(col) && new ArrayList{1, 3, 5, 6, 8, 9, 11, 14 }.Contains(row))
					&& !(new ArrayList{0, 18}.Contains(col) && new ArrayList{5, 6, 8, 9}.Contains(row))
					&& !(new ArrayList{5,6,7,9, 11, 12, 13, 14}.Contains(col) && new ArrayList{1, 11, 14}.Contains(row))
					&& !(new ArrayList{7, 8, 9, 10, 11}.Contains(col) && new ArrayList{3, 7, 8}.Contains(row))
					&& !(col == 9 && new ArrayList{0, 4, 10, 13}.Contains(row))
					&& !(col == 13 && new ArrayList{3, 4, 5, 6, 8, 9, 13}.Contains(row))
					&& !(new ArrayList{4, 15}.Contains(col) && row == 14)
					&& !(new ArrayList{3, 16}.Contains(col) && row == 12)
					&& !(new ArrayList{6, 7, 9, 11, 12}.Contains(col) && row == 5)
					&& !(new ArrayList{5, 14}.Contains(col) && new ArrayList{3, 4, 5, 6, 8, 9, 12, 13}.Contains(row)) ) {
					Instantiate(gameObject, new Vector3(x, y, 0F), Quaternion.identity);
				}
				if (new ArrayList{0, 1, 2, 3}.Contains(col)) {
					x += (ballSize - 0.04F);
				} else if (new ArrayList{13, 14}.Contains(col)) {
					x += (ballSize - 0.14F);
				} else if (new ArrayList{6, 7, 8, 9, 10, 11, 15, 16, 17}.Contains(col)) {
					x += (ballSize + 0.05F);
				} else {
					x += ballSize;
				}
			}
			if ( row == 1 ) {
				y -= (ballSize + 0.1F);
			} else if ( new ArrayList{6, 9, 12}.Contains(row) ) {
				y -= (ballSize + 0.38F);
			} else if ( row == 5 ) {
				y -= (ballSize - 0.08F);
			} else if ( new ArrayList{7, 8}.Contains(row) ) {
				y -= (ballSize - 0.1F);
			} else if ( new ArrayList{2, 3, 10, 11, 13, 14}.Contains(row) ) {
				y -= (ballSize - 0.15F);
			} else if ( row == 4 ) {
				y -= (ballSize - 0.18F);
			} else {
				y -= ballSize;
			}
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