using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	public Text player1Score;
	public Text player2Score;
	
	// Update is called once per frame
	void Update () {
		player1Score.text = "Player 1 : " + GameManager.player1Points;
		player2Score.text = "Player 2 : " + GameManager.player2Points;
	}
}
