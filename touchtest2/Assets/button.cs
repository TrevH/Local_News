using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {

	public Color defaultColor;
	public Color selectedColor;

	private Material mat;

	void Start() {
		mat = GetComponent<Renderer>().material;
	}

	void onTouchDown() {
		mat.color = selectedColor;
	}

	void onTouchUp() {
		mat.color = defaultColor;
	}

	void onTouchMove() {
		mat.color = selectedColor;
	}

	void onTouchExit() {
		mat.color = defaultColor;
	}

}
