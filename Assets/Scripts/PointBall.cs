using UnityEngine;
using System.Collections;

public class PointBall: MonoBehaviour {
	public GameObject pacman;
	public GameObject pointBall;
	public static GameObject staticPointBall = null;
	// Use this for initialization
	void Start() {
		Invoke("createBalls", 1);
	}

	// Update is called once per frame
	void Update() {
		PacmanCollision();
	}

	void PacmanCollision() {
		// TODO
		float pacmanPosX = pacman.GetComponent < Transform > ().position.x,
			pacmanPosY = pacman.GetComponent < Transform > ().position.y,
			ballPosX = transform.position.x,
			ballPosY = transform.position.z;
		
		if (PacmanInX(ballPosX, pacmanPosX) && PacmanInY(ballPosY, pacmanPosY)) {
			// TODO
			Debug.Log("Pacman gets the ball");
		}
	}

	bool PacmanInX(float ballPosX, float pacmanPosX) {
		if (ballPosX >= 0) {
			if ( pacmanPosX >= (ballPosX - 0.3) && pacmanPosX <= (ballPosX + 0.3) ) {
				return true;
			}
		} else { // -1.05 <=> -0.95
			if ( pacmanPosX <= (ballPosX - 0.3) && pacmanPosX >= (ballPosX + 0.3) ) {
				return true;
			}
		}
		return false;
	}

	bool PacmanInY(float ballPosY, float pacmanPosY) {
		if (ballPosY >= 0) { // pm >= 0.26 && pm <= 0.36 
			if ( pacmanPosY >= (ballPosY - 0.3) && pacmanPosY <= (ballPosY + 0.3) ) {
				return true;
			}
		} else {	
			if ( pacmanPosY <= (ballPosY - 0.3) && pacmanPosY >= (ballPosY + 0.3) ) {
				return true;
			}
		}
		return false;
	}

	void createBalls() {
		PointBall.staticPointBall = PointBall.staticPointBall == null ? instantiateBalls() : PointBall.staticPointBall;
	}

	GameObject instantiateBalls() {
		GameObject target = (GameObject)Instantiate(pointBall, new Vector3(5.0F, 0.3F, 0F), Quaternion.identity);
		return target; 
	}

}


/*
	Balls positioned below zero
	-5.49 - 0.05 = -5.54
	-5.49 + 0.05 = -5.44
	Balls positioned above zero
	5.49 - 0.05 = 5.44
	5.49 + 0.05 = 5.54
	
	Balls positioned below zero
	-0.31 - 0.05 = -0.36
	-0.31 + 0.05 = -0.26
	Balls positioned above zero
	0.31 - 0.05 = 0.26
	0.31 + 0.05 = 0.36
*/