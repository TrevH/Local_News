using System;
using TouchScript.Gestures;
using UnityEngine;

public class basicButton : MonoBehaviour {


	private void OnEnable()
	{
		GetComponent<TapGesture>().Tapped += tappedHandler;
	}

	private void OnDisable()
	{
		GetComponent<TapGesture>().Tapped -= tappedHandler;
	}

	private void keyPressed()
	{
		// Simulate the key pressed here
	}

	private void tappedHandler(object sender, EventArgs eventArgs)
	{
		keyPressed();
	}
}
