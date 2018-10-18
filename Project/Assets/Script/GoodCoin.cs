using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodCoin : MonoBehaviour {
    public float rSpeed, rSpeed2;
    public int collected;
	// Use this for initialization
	void Start () {
        rSpeed = 80.0f;
        rSpeed2 = 40.0f;
        collected = 0;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Rotate(Vector3.up * Time.deltaTime * rSpeed);
        gameObject.transform.Rotate(Vector3.right * Time.deltaTime * rSpeed2);
        gameObject.transform.Rotate(Vector3.back * Time.deltaTime * rSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.Equals("player")) {
            collected++;
            Destroy(this.gameObject);
        }
    }
}
