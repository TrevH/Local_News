using System;
using TouchScript.Gestures;
using UnityEngine;

public class debugRefreshNews : MonoBehaviour {

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
		mastercontroller.RefreshNews = true;
	}

	private void tappedHandler(object sender, EventArgs eventArgs)
	{
		keyPressed();
	}
}
