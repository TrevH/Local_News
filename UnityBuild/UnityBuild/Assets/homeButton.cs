using System;
using TouchScript.Gestures;
using UnityEngine;

public class homeButton : MonoBehaviour {

	private void OnEnable()
	{
		GetComponent<TapGesture>().Tapped += tappedHandler;
	}

	private void OnDisable()
	{
		GetComponent<TapGesture>().Tapped -= tappedHandler;
	}

	private void goHome()
	{
		Application.LoadLevel ("earthview");
	}

	private void tappedHandler(object sender, EventArgs eventArgs)
	{
		goHome();
	}
}
