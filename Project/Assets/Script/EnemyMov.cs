using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMov : MonoBehaviour {

    public int enSpeed, liveLost, currentScene;
    Vector3 originalPosZ, originalPosX, originalPosX1, playerOriPos, hightFix;
    Vector3[] en1Z = new Vector3[7];
    GameObject enemy0, enemy1, enemy2, player0;

    public AudioSource crash;
	
    // Use this for initialization
	void Start () {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        enSpeed = 3;
        liveLost = 0;
        player0 = GameObject.Find("player");
        enemy0 = GameObject.Find("Enemy");
        enemy1 = GameObject.Find("Enemy (1)");
        enemy2 = GameObject.Find("Enemy (2)");
        playerOriPos = player0.transform.position;
        originalPosZ = enemy0.transform.position;
        originalPosX = enemy1.transform.position;
        originalPosX1 = enemy2.transform.position;
        hightFix = new Vector3 (0,1.5f,0);
        crash = GetComponent<AudioSource>();

        // Enemy (1) Z positions.

        en1Z[0] = GameObject.Find("Cube (72)").transform.position + hightFix;
        en1Z[1] = GameObject.Find("Cube (32)").transform.position + hightFix;
        en1Z[2] = GameObject.Find("Cube (24)").transform.position + hightFix;
        en1Z[3] = GameObject.Find("Cube (8)").transform.position + hightFix;
        en1Z[4] = GameObject.Find("Cube (40)").transform.position + hightFix;
        en1Z[5] = GameObject.Find("Cube (56)").transform.position + hightFix;
        en1Z[6] = GameObject.Find("Cube (64)").transform.position + hightFix;
    }
	
	// Update is called once per frame
	void Update () {
        // Constant movement.
        enemy0.transform.Translate(Vector3.back * (Time.deltaTime * enSpeed));
        enemy1.transform.Translate(Vector3.right * (Time.deltaTime * enSpeed));
        enemy2.transform.Translate(Vector3.left * (Time.deltaTime * enSpeed));

        // Reset position.
        if (enemy0.transform.position.z < -8) {
            enemy0.transform.position = originalPosZ;
        }
        if (enemy1.transform.position.x > 7) {
            //if (currentScene == 1){
            //    enemy1.transform.position = originalPosX;
            //}
            //if (currentScene == 2){
                enemy1.transform.position = en1Z[Random.Range(0,6)];
            //}
        }
        if (enemy2.transform.position.x < -7) {
            enemy2.transform.position = originalPosX1;
        }
        if (currentScene == 2) {
            enSpeed = 5;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name.Equals("player")) {
            crash.Play();
            liveLost++;
            player0.transform.position = playerOriPos;
        }
    }
}
