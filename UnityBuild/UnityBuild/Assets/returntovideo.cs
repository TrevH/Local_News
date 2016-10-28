using UnityEngine;
using System.Collections;

public class returntovideo : MonoBehaviour {
	
	private Vector3 tmpMousePosition;
	private int count;


	void Start(){
		tmpMousePosition = Input.mousePosition;
		count = 0;

	}


	void FixedUpdate(){


		if (tmpMousePosition != Input.mousePosition) {
			Debug.Log ("Mouse moved");
			tmpMousePosition = Input.mousePosition;
		} else if (count == 1200) {
			Application.LoadLevel ("PlanetVideoScene");
		} else {
			count++;
		}


	}
}
