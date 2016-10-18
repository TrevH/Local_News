using System;
using TouchScript.Gestures;
using UnityEngine;

public class RemoveBox : MonoBehaviour {


	private void OnEnable()
	{
		GetComponent<TapGesture>().Tapped += tappedHandler;
	}

	private void OnDisable()
	{
		GetComponent<TapGesture>().Tapped -= tappedHandler;
	}

	private void removeObject()
	{
		Destroy (gameObject);
	}

	private void tappedHandler(object sender, EventArgs eventArgs)
	{
		removeObject();
	}
}
