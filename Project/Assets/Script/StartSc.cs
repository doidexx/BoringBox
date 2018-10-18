using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSc : MonoBehaviour {

	public void onStartGame(){
		SceneManager.LoadScene(1);
	}
}
