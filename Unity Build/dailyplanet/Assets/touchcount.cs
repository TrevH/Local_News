using UnityEngine;
using System.Collections;

public class touchcount : MonoBehaviour {
	public GUIText texti;
	// Use this for initialization
	void Start () {
		texti = GameObject.Find("displaytouches").GetComponent<GUIText>();
	}
	
	// Update is called once per frame
	void Update () {
		int fingerCount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
				fingerCount++;

		}
		if (fingerCount > 0)
			texti.text = "User(s) have " + fingerCount + " finger(s) touching the screen";
		if (fingerCount == 0)
			texti.text = "User(s) have " + "0" + " finger(s) touching the screen";
	}
}
