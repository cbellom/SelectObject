using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectClickable : MonoBehaviour {

	public List<Color> colors;

	public int indexCurrentColor;
	// Use this for initialization
	void Start () {
		SetupDefaultColor ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		if(GameStateBehaviour.GameState == GameState.Pause)
			RotateMaterialColor ();
	}


	void SetupDefaultColor () {
		if (colors.Count > 0) {
			indexCurrentColor = 0;
			ChangeMaterialMainColorTo (colors [indexCurrentColor]);
		}
	}

	void ChangeMaterialMainColorTo(Color color){		
		this.renderer.material.color = color;
	}

	void RotateMaterialColor ()	{
		indexCurrentColor = (indexCurrentColor + 1) % colors.Count;
		ChangeMaterialMainColorTo(colors[indexCurrentColor]);
	}
}
