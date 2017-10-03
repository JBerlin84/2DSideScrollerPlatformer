using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public float speed = 10;
	public KeyCode upKey;
	public KeyCode downKey;

	Transform t;
	Vector2 screenSize = new Vector2(20, 10);

	float topPosition;
	float bottomPosition;

	// Use this for initialization
	void Start () {
		t = GetComponent<Transform> ();

		topPosition = screenSize.y / 2 - t.localScale.y / 2;
		bottomPosition = -topPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (upKey)) {
			t.Translate (new Vector2 (0, speed * Time.deltaTime));
		}
		if (Input.GetKey (downKey)) {
			t.Translate (new Vector2 (0, -speed * Time.deltaTime));
		}

		if (t.position.y > topPosition) {
			t.position = new Vector3 (t.position.x, topPosition, t.position.z);
		} else if (t.position.y < bottomPosition) {
			t.position = new Vector3 (t.position.x, bottomPosition, t.position.z);
		}
	}
}
