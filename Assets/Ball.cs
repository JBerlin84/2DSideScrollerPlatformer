using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector2 ballSpeed;
	Vector2 velocity;
	Vector2 screenSize = new Vector2(20, 10);

	Transform t;

	float rightBorder;
	float leftBorder;
	float topBorder;
	float bottomBorder;

	void Start() {
		t = GetComponent<Transform> ();

		rightBorder = screenSize.x / 2 - t.localScale.x / 2;
		leftBorder = -rightBorder;

		topBorder = screenSize.y / 2 - t.localScale.y / 2;
		bottomBorder = -topBorder;

		print ("Bottom: " + bottomBorder);
		print ("top: " + topBorder);
		print ("left: " + leftBorder);
		print ("Right: " + rightBorder);


		reset ();
	}

	// Update is called once per frame
	void Update () {
		t.Translate (velocity*Time.deltaTime);

		if (t.position.y > topBorder) {
			velocity = new Vector2 (velocity.x, -Mathf.Abs(velocity.y));
		} else if (t.position.y < bottomBorder) {
			velocity = new Vector2 (velocity.x, Mathf.Abs(velocity.y));
		}


		if (t.position.x > rightBorder) {
			GameManager.player1Points = GameManager.player1Points + 1;
			reset ();
		} else if (t.position.x < leftBorder) {
			GameManager.player2Points = GameManager.player2Points + 1;
			reset ();
		}
	}

	/// <summary>
	/// Check if we are hitting any paddles.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag.Equals("Player")) {
			velocity = new Vector2 (-velocity.x, velocity.y);
		}
	}

	/// <summary>
	/// Reset the ball.
	/// </summary>
	void reset() {
		print ("reset");
		t.position = new Vector3 (0, 0, 0);

		float xDirection = 1f;
		float yDirection = 1f;
		if (Random.value < 0.5f) {
			xDirection *= -1;
		}
		if (Random.value < 0.5f) {
			yDirection *= -1;
		}

		velocity = new Vector2 (ballSpeed.x * xDirection, ballSpeed.y * yDirection);
	}
}
