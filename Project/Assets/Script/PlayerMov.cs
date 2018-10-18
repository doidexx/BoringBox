using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMov : MonoBehaviour {
    public int moves, lifes, collectedCoin;
    public float speed;
    public AudioSource Collector;

    private int current;
	// Use this for initialization
	void Start () {
        speed = 2f;
        moves = 0;
        lifes = 3;
        collectedCoin = 0;
        Collector = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        // Get current Scene.
        current = SceneManager.GetActiveScene().buildIndex;

        if (Input.GetKeyDown(KeyCode.W) && transform.position.z < 8f)
        {
            moves += 1;
            gameObject.transform.Translate(Vector3.forward * speed);
        }
        if (Input.GetKeyDown(KeyCode.S) && transform.position.z > -8f)
        {
            moves += 1;
            gameObject.transform.Translate(Vector3.back * speed);
        }
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -7f)
        {
            moves += 1;
            gameObject.transform.Translate(Vector3.left * speed);
        }
        if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 7f)
        {
            moves += 1;
            gameObject.transform.Translate(Vector3.right * speed);
        }
        if (lifes == 0) {
            SceneManager.LoadScene(4);
        }
        if (collectedCoin == 6 && current == 1){
            collectedCoin = 0;
            SceneManager.LoadScene(2);
        }
        if (current == 2 && collectedCoin == 6){
            SceneManager.LoadScene(3);
        }
    }
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.name.Equals("Enemy") || other.gameObject.name.Equals("Enemy (1)") || other.gameObject.name.Equals("Enemy (2)")) {
            lifes--;
        }
        if (other.gameObject.name.Equals("Coin") || other.gameObject.name.Equals("Coin (1)") || other.gameObject.name.Equals("Coin (2)") ||
        other.gameObject.name.Equals("Coin (3)") || other.gameObject.name.Equals("Coin (4)") || other.gameObject.name.Equals("Coin (5)")){
            Collector.Play();
            collectedCoin++;
        }
    }
}
