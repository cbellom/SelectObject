using UnityEngine;
using System.Collections;

public class SceneObjects  {
	private Shader[] allShareds;
	public GameObject[] allObjects;

	public void FindAllObjectInScene(){
		allObjects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
		allShareds = new Shader[allObjects.Length];
	}

	public void ClearObjects(){
		for (int index = 0; index < allObjects.Length; index++) {
			GameObject gameObject = allObjects [index];
			if (DoesTheObjectHasMaterial (gameObject)) {
				SaveSharedInIndex(index, gameObject);
				if(IsNotClickable(gameObject))
					ChangeToTransparentShaderOf (gameObject);
			}
		}
	}

	public void RestartObjects(){
		for (int index = 0; index < allObjects.Length; index++) {
			GameObject gameObject = allObjects [index];
			if (DoesTheObjectHasMaterial (gameObject)) {
				if(IsNotClickable(gameObject))
					ReloadSharedInIndex(index, gameObject);
			}
		}
	}

	private bool DoesTheObjectHasMaterial (GameObject gameObject) {
		if(gameObject.GetComponent<Renderer>() != null && gameObject.renderer.material != null)
			return true;

		return false;
	}

	private void SaveSharedInIndex(int index, GameObject gameObject){
		Shader shared = gameObject.renderer.sharedMaterial.shader;
		allShareds[index] = shared;
	}

	private void ReloadSharedInIndex (int index, GameObject gameObject) {
		gameObject.renderer.sharedMaterial.shader = allShareds [index];
	}

	private void ChangeToTransparentShaderOf (GameObject gameObject){
		Shader shared = Shader.Find("Transparent/Diffuse");;
		gameObject.renderer.sharedMaterial.shader = shared;
	}


	private bool IsNotClickable (GameObject gameObject)	{
		return gameObject.GetComponent<ObjectClickable>() == null;
	}
}
