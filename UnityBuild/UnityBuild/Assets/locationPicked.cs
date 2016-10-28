using System;
using TouchScript.Gestures;
using UnityEngine;

public class locationPicked : MonoBehaviour {

	private void OnEnable()
	{
		GetComponent<TapGesture>().Tapped += tappedHandler;
	}

	private void OnDisable()
	{
		GetComponent<TapGesture>().Tapped -= tappedHandler;
	}

	private void goInterface()
	{
		Application.LoadLevel ("newmainInterface");
	}

	private void tappedHandler(object sender, EventArgs eventArgs)
	{
		goInterface();
	}
}
