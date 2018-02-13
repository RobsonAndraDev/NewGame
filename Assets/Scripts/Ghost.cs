using UnityEngine;
using System.Collections;
using System.Threading;

public class Ghost : MonoBehaviour {
	public GameObject pink;
	public GameObject red;
	public GameObject blue;
	public GameObject yellow;
	public static GameObject pinkGhost = null;
	public static GameObject redGhost = null;
	public static GameObject blueGhost = null;
	public static GameObject yellowGhost = null;
	private bool alertTime = false;

	// Use this for initialization
	void Start () {
		Invoke("createGhost", 1);
		InvokeRepeating("callAlertMode", 30f, 30f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void createGhost() {
		Ghost.pinkGhost = Ghost.pinkGhost == null ? instantiateGhost(pink) : Ghost.pinkGhost;
		Ghost.redGhost = Ghost.redGhost == null ? instantiateGhost(red) : Ghost.redGhost;
		Ghost.blueGhost = Ghost.blueGhost == null ? instantiateGhost(blue) : Ghost.blueGhost;
		Ghost.yellowGhost = Ghost.yellowGhost == null ? instantiateGhost(yellow) : Ghost.yellowGhost;
	}

	GameObject instantiateGhost(GameObject ghost) {
		GameObject target = (GameObject)Instantiate(ghost, new Vector3(0F, 0.25F, 0F), Quaternion.identity);
		target.name = ghost.name.Replace("Ghost(Clone)", "") ;
		//Debug.Log(target.name);
		return target; 
	}

	void callAlertMode() {
		alertMode(Ghost.pinkGhost);
		alertMode(Ghost.redGhost);
		alertMode(Ghost.blueGhost);
		alertMode(Ghost.yellowGhost);
		alertTime = alertTime ? false : true;
	}

	void alertMode(GameObject ghost) {
		// Debug.Log("Called: " + alertTime);
		if(ghost != null) {
			ghost.GetComponent<Animator>().SetBool("alert", alertTime);
		}
	}
}
