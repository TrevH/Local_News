using System;
using TouchScript.Gestures;
using UnityEngine;

public class DebugAddTweet : MonoBehaviour {

	private void OnEnable()
	{
		GetComponent<TapGesture>().Tapped += tappedHandler;
	}

	private void OnDisable()
	{
		GetComponent<TapGesture>().Tapped -= tappedHandler;
	}

	private void addObject()
	{
		Instantiate(Resources.Load ("TweeterBox"), new Vector3 (0.0f, 0.0f, 7), Quaternion.Euler (0, 0, 0));
	}

	private void tappedHandler(object sender, EventArgs eventArgs)
	{
		addObject();
	}
}
