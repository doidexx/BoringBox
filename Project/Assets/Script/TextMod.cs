using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMod : MonoBehaviour {
	public Text collectedText, restText;
	public int collectedCount, lifesRest;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once perframe
	void Update () {
		lifesRest = GameObject.Find("player").GetComponent<PlayerMov>().lifes;
		collectedCount = GameObject.Find("player").GetComponent<PlayerMov>().collectedCoin;
		collectedText.text = "Collected Coins: " + collectedCount.ToString();
		restText.text = "Lifes: " + lifesRest.ToString();
	}

}
