using UnityEngine;
using System.Collections;
using UnitySampleAssets.Characters.FirstPerson;

public class GameStateBehaviour : MonoBehaviour {
	[SerializeField]
	private static GameState gameState;
	private FirstPersonController playerControler;
	private SceneObjects sceneObjects;
	// Use this for initialization
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		playerControler = GetFirstPersonControllerFrom (player);

		gameState = GameState.Resume;
		sceneObjects = new SceneObjects ();
		sceneObjects.FindAllObjectInScene ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Tab)) {
			if (gameState == GameState.Resume) {
				LockFirstPersonController ();
				sceneObjects.ClearObjects();
				gameState = GameState.Pause;
			} else {
				UnlockFirstPersonController ();
				sceneObjects.RestartObjects();
				gameState = GameState.Resume;
			}
		}
	}

	public static GameState GameState {
		get {
			return gameState;
		}
	}

	private FirstPersonController GetFirstPersonControllerFrom(GameObject player){
		return player.GetComponent<FirstPersonController> ();
	}

	private void LockFirstPersonController () {
		if (playerControler != null)
			playerControler.enabled = false;
	}

	private void UnlockFirstPersonController () {
		if (playerControler != null)
			playerControler.enabled = true;
	}
}
