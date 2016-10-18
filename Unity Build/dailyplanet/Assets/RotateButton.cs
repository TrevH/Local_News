using System;
using TouchScript.Gestures;
using UnityEngine;

public class RotateButton : MonoBehaviour {
	private Boolean isSouth = true;
	private Boolean pressed = false;
	private GameObject GOCamera;

	private void OnEnable()
	{
		GetComponent<TapGesture>().Tapped += tappedHandler;
	}

	private void OnDisable()
	{
		GetComponent<TapGesture>().Tapped -= tappedHandler;
	}

	private void rotateObjects()
	{
//		selectorArrNewsBox = MSscript.selectorArrNewsBox;
//		selectorArrTweeterBox = MSscript.selectorArrTweeterBox;
		GOCamera = GameObject.Find("Main Camera");
//		for (int i = 0; i < 6; i++) {
//			Physics2D.IgnoreCollision (selectorArrNewsBox[i].GetComponent<Collider2D>(), selectorArrTweeterBox[i].GetComponent<Collider2D>(), true);
//
//		}
		pressed = true;
	}

	private void tappedHandler(object sender, EventArgs eventArgs)
	{
		rotateObjects();
	}

	void FixedUpdate () {
		if (pressed) {
			if (isSouth) {
				if (GOCamera.transform.rotation == new Quaternion (0.0f, 0.0f, 1.0f, 0.0f) && isSouth) {
					pressed = false;
					isSouth = false;
				} else {
					GOCamera.transform.Rotate (Vector3.forward, 500.0f * Time.deltaTime);
				}
			} else {
				if (GOCamera.transform.rotation == new Quaternion (0.0f, 0.0f, 0.0f, 1.0f) && !isSouth) {
					pressed = false;
					isSouth = true;
				} else {
					GOCamera.transform.Rotate (Vector3.back, 500.0f * Time.deltaTime);
				}
			}
			//print (GOCamera.transform.rotation);
//			for (int i = 0; i < 6; i++) {
//				if (isSouth) {
//					if (selectorArrNewsBox [i].transform.position == new Vector3 (5.21f, 3.4f - (1.2f * i), 7)) {
//						pressed = false;
//					} else {
//						selectorArrNewsBox [i].transform.position = Vector2.Lerp (selectorArrNewsBox [i].transform.position, new Vector2 (5.21f, 3.4f - (1.2f * i)), 1.0f * Time.fixedDeltaTime);
//					}
//				} else {
//					
//				}
//			}
		}
	}
}
